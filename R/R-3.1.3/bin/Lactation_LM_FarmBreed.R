args=(commandArgs(trailingOnly = TRUE))
if(length(args)<2){
	stop("No enough arguments supplied!")
}

iFileName <- args[1]
oFileName <- args[2]

print(iFileName)

LWdata <- read.table(iFileName, header = TRUE, sep=",")

#LWdata <- LWdata[is.na(LWdata)==FALSE,]
LWdata <- LWdata[complete.cases(LWdata),]

LWdata$dim2 <- LWdata$dim * LWdata$dim
LWdata$dim3 <- LWdata$dim2 * LWdata$dim

str(LWdata)

# a * System.Math.Pow(t, b) * System.Math.Exp(-c * t)

#head(LWdata)

library(arm)


print('test')


#str(linear_model)



png(oFileName, width = 960, height = 960, units = "px", pointsize = 12) 



tryCatch({

farms <- levels(LWdata$Farm);
farm_count <- nlevels(LWdata$Farm)

breeds <- levels(LWdata$Breed)
breed_count <- nlevels(LWdata$Breed)

row_count <- as.integer(ceiling(sqrt(farm_count * breed_count)))

if(row_count < 1) row_count <- 1
if(row_count > 5) row_count <- 5

total_count <- row_count * row_count

par(mfrow=c(row_count,row_count)) # all plots on one page 

count <- 0

for(farm in farms)
{
	LWdataC <- LWdata[which(LWdata$Farm==farm),]
	for(breed in breeds)
	{
		if(count >= total_count) break
		
		LWdataB <- LWdataC[which(LWdataC$Breed==breed),]
		
		if(length(LWdataB$dim) > 0)
		{
			head(LWdataB)
			
			str(LWdataB)

			linear_model <- lm(milk ~ dim + dim2 + dim3, data=LWdataB);
			#linear_model <-  glm(milk ~ dim + dim2 + dim3, family=poisson(), data=LWdataB)
			display(linear_model)
				
			par(pch=22, col="gray") # plotting symbol and color 
			plot(LWdataB$dim, LWdataB$milk, type='p', xlab='DIM', ylab='Milk', main=paste('Farm = ', farm, ', Breed = ', breed))
			
			new_dim <- seq(min(LWdataB$dim), max(LWdataB$dim), 5);
			new_dim2 <- new_dim * new_dim
			new_dim3 <- new_dim2 * new_dim
			new <- data.frame(dim = new_dim, dim2 = new_dim2, dim3 = new_dim3)

			par(pch=22, col="blue") # plotting symbol and color 
			lines(new_dim, predict(linear_model, new))

			count <- count+1
		}
	}
}


}, error=function(err){
print(err)
})

detach(LWdata)

print('test')

dev.off()







