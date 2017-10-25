args=(commandArgs(trailingOnly = TRUE))
if(length(args)<2){
	stop("No enough arguments supplied!")
}

iFileName <- args[1]
oFileName <- args[2]

print(iFileName)

LWdata <- read.csv(iFileName, header = TRUE, sep=",")

LWdata <- LWdata[complete.cases(LWdata),]

LWdata$dim2 <- LWdata$dim * LWdata$dim
LWdata$dim3 <- LWdata$dim2 * LWdata$dim


# a * System.Math.Pow(t, b) * System.Math.Exp(-c * t)

head(LWdata)
str(LWdata)

library(lme4)
library(arm)



png(oFileName, width = 960, height = 960, units = "px", pointsize = 12) 


tryCatch({

linear_model <- lmer(milk ~ dim + dim2 + dim3 + (1 + dim + dim2|Farm/Breed), data=LWdata)
	display(linear_model)

cows <- unique(unlist(LWdata[1], use.names = FALSE));

cow_count <- length(cows)

row_count <- as.integer(ceiling(sqrt(cow_count)))

if(row_count < 1)
{
	row_count <- 1
}
else if(row_count > 5)
{
	row_count <- 5
}



par(mfrow=c(row_count,row_count)) # all plots on one page 

total_count <- row_count * row_count
count <- 0
for(cow in cows)
{
	if(count >= total_count)
	{
		break
	}
	LWdataB <- LWdata[which(LWdata[1]==cow),]
	
	LWdataB <- LWdataB[order(LWdataB$dim), ]
	
	
		
	par(pch=22, col="black") # plotting symbol and color 
	plot(LWdataB$dim, LWdataB$milk, type='p', xlab='DIM', ylab='Milk')
	par(pch=15, col="red") # plotting symbol and color 
	
	new = data.frame(dim=LWdataB$dim, dim2=LWdataB$dim2, dim3=LWdataB$dim3, Breed=LWdataB$Breed, Farm=LWdataB$Farm)
	
	lines(LWdataB$dim, predict(linear_model, new), type='l')
	
	count <- count+1
}


}, error=function(err){
print(err)
})

detach(LWdata)

dev.off()





