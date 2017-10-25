args=(commandArgs(trailingOnly = TRUE))
if(length(args)<2){
	stop("No enough arguments supplied!")
}

iFileName <- args[1]
oFileName <- args[2]
##oFileName <- paste(oFileName, "ChiSq_vs_MLM_Breed.png",sep="_")
print(iFileName)
print(oFileName)

LWdata <- read.table(iFileName, header = TRUE, sep=",")

LWdata <- LWdata[complete.cases(LWdata),]

LWdata$dim2 <- LWdata$dim * LWdata$dim
LWdata$dim3 <- LWdata$dim2 * LWdata$dim

#str(LWdata)

library(arm)
#str(linear_model)

png(oFileName, width = 960, height = 960, units = "px", pointsize = 12) 

tryCatch({

print('Multi Level Model: Varying Intercept and 1 Slope with Breed for the 2nd order')
mlm_model1 <- lmer(milk ~ dim + dim2 + dim3 + (1 + dim + dim2 |Breed), LWdata)
print(mlm_model1@call)

new_dim <- seq(min(LWdata$dim), max(LWdata$dim), 5)
new_dim2 <- new_dim * new_dim
new_dim3 <- new_dim2 * new_dim

bin_dim <- seq(min(LWdata$dim), max(LWdata$dim), 30)
bin_milk <- c();
bin_season <- c();
for(i in seq_len(length(bin_dim)))
{
	bin_lower <- bin_dim[i]
	if(i == length(bin_dim)) {
		bin_upper <- max(LWdata$dim)
    } else {
		bin_upper <- bin_dim[i+1]
	}

	LWdataB <- LWdata[(LWdata$dim >= bin_lower & LWdata$dim < bin_upper), ]
	# Added by WENJING
	if (max(LWdata$dim) - min(LWdata$dim) == (i -1) * 30) {
		LWdataB <- LWdata[(LWdata$dim >= bin_lower), ]
	}
	#
	bin_value <- mean(LWdataB$milk)
	bin_milk <- c(bin_milk, bin_value)
	bin_season <- c(bin_season, (bin_lower + bin_upper)/2)
}

bin <- data.frame(dim = bin_season, milk = bin_milk)

breeds <- levels(LWdata$Breed);

par(mfrow=c(3,3)) # all plots on one page 

chisq_lm <- c()
chisq_mlm <- c()
chisq_breed <- c()

print('Linear Model by Each Breed')
print ('linear_model <- lm(milk ~ dim + dim2 + dim3, data=LWdataB)')

for(breed in breeds)
{
	LWdataB <- LWdata[which(LWdata$Breed==breed),]
	
	#head(LWdataB)

	linear_model <- lm(milk ~ dim + dim2 + dim3, data=LWdataB);
	#display(linear_model)
		
	par(pch=22, col="gray") # plotting symbol and color
 
	#maintext <- "LM=blue, MLM=red, Overrall=green, Breed="
	maintext <- "LM and MLM vs General: Breed="
	plot(LWdataB$dim, LWdataB$milk, type='p', xlab='DIM', ylab='Milk', main=paste(maintext, breed, sep=''))	
    
	new <- data.frame(dim = new_dim, dim2 = new_dim2, dim3 = new_dim3, Breed=breed)	

	lmpred <- data.frame(dim = new_dim, milk = predict(linear_model, new))
	mlmpred <- data.frame(dim = new_dim, milk = predict(mlm_model1, new))

	bin_dim <- seq(min(LWdata$dim), max(LWdata$dim), 30)
	bin_milk_lm <- c();
	bin_milk_mlm <- c();
	bin_season <- c();
	for(i in seq_len(length(bin_dim)))
	{
		bin_lower <- bin_dim[i]
		if(i == length(bin_dim)) {
			bin_upper <- max(LWdata$dim)
		} else {
			bin_upper <- bin_dim[i+1]
		}
		
		lmpredB <- lmpred[(lmpred$dim >= bin_lower & lmpred$dim < bin_upper), ]
		# Added by WENJING
		if (max(LWdata$dim) - min(LWdata$dim) == (i -1) * 30) {
			lmpredB <- lmpred[(lmpred$dim >= bin_lower), ]
		}
		bin_value <- mean(lmpredB$milk)
		bin_milk_lm <- c(bin_milk_lm, bin_value)

		mlmpredB <- mlmpred[(mlmpred$dim >= bin_lower & mlmpred$dim < bin_upper), ]
		# Added by WENJING
		if (max(LWdata$dim) - min(LWdata$dim) == (i -1) * 30) {
			mlmpredB <- mlmpred[(mlmpred$dim >= bin_lower), ]
		}
		bin_value <- mean(mlmpredB$milk)
		bin_milk_mlm <- c(bin_milk_mlm, bin_value)
	}

	bin$milk_lm <- bin_milk_lm
	bin$milk_mlm <- bin_milk_mlm

	par(pch=19, col="blue") # plotting symbol and color 
	lines(bin$dim, bin$milk_lm,type="b") 

    par(pch=20, col="red") # plotting symbol and color 
	lines(bin$dim, bin$milk_mlm,type="b") 

	par(pch=24, col="green") # plotting symbol and color 
	lines(bin$dim, bin$milk,type="o") 
		
	# Add a legend to the plot 
	legend("topright",legend =c("Overall","LM","MLM"),col=c("green","blue","red"),pch=c(24,19,20),lty=c(1,1,1),text.col=c("black"))
	
	tryCatch({
	bin$milk_sum = sum(bin$milk)
	bin$milk_prob = bin$milk / bin$milk_sum

	lm_test <- chisq.test(bin$milk_lm, p=bin$milk_prob) 
	#print(lm_test)

	mlm_test <- chisq.test(bin$milk_mlm, p=bin$milk_prob) 
	#print(mlm_test)

	chisq_lm <- c(chisq_lm, lm_test$p.value)
	chisq_mlm <- c(chisq_mlm, mlm_test$p.value)
	chisq_breed <- c(chisq_breed, breed)
	}, error=function(err){
		print(err)			
			})
}

chisq_comparison <- data.frame(Breed = chisq_breed, lmPValue = chisq_lm, mlmPValue = chisq_mlm)

head(chisq_comparison)
print(chisq_comparison)

plot(chisq_comparison$Breed, chisq_comparison$lmPValue, pch=24, col='blue',lty=3, main='ChiSq p-value of LM vs MLM')
lines(chisq_comparison$Breed, chisq_comparison$mlmPValue,pch=19, col='red',lty=5)
# Add a legend to the plot 
legend("bottomright",legend =c("LM","MLM"),col=c("blue","red"),pch=c(24,19),lty=c(3,5),text.col=c("black"))

}, error=function(err){
print(err)
})

detach(LWdata)

print('test')

dev.off()






























