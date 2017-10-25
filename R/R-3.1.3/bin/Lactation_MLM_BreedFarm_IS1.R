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


print('Multi Level Model: Varying Intercept and 1 Slope with Breed / Farm interaction')
mlm_model1 <- lmer(milk ~ dim + dim2 + dim3 + (1 + dim|Breed / Farm), LWdata)
display(mlm_model1)
ranef(mlm_model1)

png(oFileName, width = 960, height = 960, units = "px", pointsize = 12) 



tryCatch({
	breeds <- levels(LWdata$Breed)
	farms <- levels(LWdata$Farm)
	breed_count <- nlevels(LWdata$Breed)
	farm_count <- nlevels(LWdata$Farm)
	
	row_count <- as.integer(ceiling(sqrt(breed_count * farm_count)))
	
	if(row_count < 1) row_count = 1
	else if(row_count > 5) row_count = 5
	
	total_count <- row_count * row_count
	
	par(mfrow=c(row_count,row_count)) # all plots on one page 

	LWdata$pred.milk <- predict(mlm_model1)
	
	count <- 0
	for(breed in breeds)
	{
		LWdataC <- LWdata[(LWdata$Breed==breed), ]
		print('test')
		for(farm in farms)
		{
			if(count >= total_count) break
			
			par(pch=22, col="blue") # plotting symbol and color 

			LWdataB <- LWdataC[(LWdataC$Farm==farm),]
			
			LWdataB <- LWdataB[order(LWdataB$dim),]
			
			if(length(LWdataB$dim) > 0)
			{
				str(LWdataB)
				
				par(pch=22, col="gray") # plotting symbol and color 
				plot(LWdataB$dim, LWdataB$milk, type='p', xlab='DIM', ylab='Milk', main=paste('Breed = ', breed, ' and Farm = ', farm))
				
				new_dim <- seq(min(LWdataB$dim), max(LWdataB$dim), 5);
				new_dim2 <- new_dim * new_dim
				new_dim3 <- new_dim2 * new_dim
				new <- data.frame(dim = new_dim, dim2 = new_dim2, dim3 = new_dim3, Breed=breed, Farm=farm)

				par(pch=22, col="blue") # plotting symbol and color 
				lines(new_dim, predict(mlm_model1, new))

				count <- count + 1
			}
		}
	}
}, error=function(err){
print(err)
})

detach(LWdata)

print('test')

dev.off()




