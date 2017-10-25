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

library(arm)
library(MASS)


png(oFileName, width = 960, height = 960, units = "px", pointsize = 12) 



tryCatch({

ldahist(LWdata$milk, LWdata$Breed, 'Milk distribution grouped by Breed')
}, error=function(err){
print(err)
})

detach(LWdata)

print('test')

dev.off()
