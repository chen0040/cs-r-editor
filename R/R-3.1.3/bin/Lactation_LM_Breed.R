args=(commandArgs(trailingOnly = TRUE))
if(length(args)<2){
	stop("No enough arguments supplied!")
}

iFileName <- args[1]
oFileName <- args[2]

print(iFileName)

LWdata <- read.table(iFileName, header = TRUE, sep=",")

LWdata <- LWdata[complete.cases(LWdata),]

LWdata$dim2 <- LWdata$dim * LWdata$dim
LWdata$dim3 <- LWdata$dim2 * LWdata$dim

str(LWdata)

library(arm)




#str(linear_model)



png(oFileName, width = 960, height = 960, units = "px", pointsize = 12) 



tryCatch({

breeds <- levels(LWdata$Breed);

par(mfrow=c(3,3)) # all plots on one page 

for(breed in breeds)
{
	LWdataB <- LWdata[which(LWdata$Breed==breed),]
	
	head(LWdataB)

	linear_model <- lm(milk ~ dim + dim2 + dim3, data=LWdataB);
	display(linear_model)
		
	par(pch=22, col="gray") # plotting symbol and color 
	plot(LWdataB$dim, LWdataB$milk, type='p', xlab='DIM', ylab='Milk')
	
	new_dim <- seq(min(LWdataB$dim), max(LWdataB$dim), 5);
	new_dim2 <- new_dim * new_dim
	new_dim3 <- new_dim2 * new_dim
	new <- data.frame(dim = new_dim, dim2 = new_dim2, dim3 = new_dim3)

	par(pch=22, col="blue") # plotting symbol and color 
	lines(new_dim, predict(linear_model, new)) 
}


}, error=function(err){
print(err)
})

detach(LWdata)

print('test')

dev.off()





