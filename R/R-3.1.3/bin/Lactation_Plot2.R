args=(commandArgs(trailingOnly = TRUE))
if(length(args)<2){
	stop("No enough arguments supplied!")
}

iFileName <- args[1]
oFileName <- args[2]

LWdata <- read.table(iFileName, header = TRUE, sep=",")

LWdata <- LWdata[complete.cases(LWdata),]

library(arm)

linear_model <- lm(milk ~ dim, data=LWdata);
display(linear_model)
#str(linear_model)




