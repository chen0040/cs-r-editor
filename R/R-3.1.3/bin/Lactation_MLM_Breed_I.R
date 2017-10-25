args=(commandArgs(trailingOnly = TRUE))
if(length(args)<2){
	stop("No enough arguments supplied!")
}

iFileName <- args[1]
oFileName <- args[2]

LWdata <- read.table(iFileName, header = TRUE, sep=",")

LWdata <- LWdata[complete.cases(LWdata),]

LWdata$dim2 <- LWdata$dim * LWdata$dim
LWdata$dim3 <- LWdata$dim2 * LWdata$dim

library(lme4)
library(arm)


print('Multi Level Model: Varying Intercept with Breed')
mlm_model1 <- lmer(milk ~ dim + dim2 + dim3 + (1|Breed), LWdata)
display(mlm_model1)
ranef(mlm_model1)

png(oFileName, width = 960, height = 960, units = "px", pointsize = 12) 



tryCatch({
	breeds <- levels(LWdata$Breed)
	breed_count <- nlevels(LWdata$Breed)
	
	row_count <- as.integer(ceiling(sqrt(breed_count)))
	
	if(row_count < 1) row_count = 1
	else if(row_count > 5) row_count = 5
	
	total_count <- row_count * row_count
	
	par(mfrow=c(row_count,row_count)) # all plots on one page 

	LWdata$pred.milk <- predict(mlm_model1)
	
	count <- 0
	for(breed in breeds)
	{
		if(count >= total_count) break
		
		par(pch=22, col="blue") # plotting symbol and color 

		LWdataB <- LWdata[(LWdata$Breed==breed),]
		
		LWdataB <- LWdataB[order(LWdataB$dim),]
		
		str(LWdataB)
		
		par(pch=22, col="gray") # plotting symbol and color 
		plot(LWdataB$dim, LWdataB$milk, type='p', xlab='DIM', ylab='Milk', main=paste('Breed = ', breed))
		
		
		new_dim <- seq(min(LWdataB$dim), max(LWdataB$dim), 5);
		new_dim2 <- new_dim * new_dim
		new_dim3 <- new_dim2 * new_dim
		new <- data.frame(dim = new_dim, dim2 = new_dim2, dim3 = new_dim3, Breed=breed)

		par(pch=22, col="blue") # plotting symbol and color 
		lines(new_dim, predict(mlm_model1, new))

		count <- count + 1
	}
}, error=function(err){
print(err)
})

detach(LWdata)

print('test')

dev.off()



