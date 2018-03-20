library(XML) 

args=(commandArgs(trailingOnly = TRUE))
if(length(args)<1){
	stop("No enough arguments supplied!")
}

iFileName <- args[1]
oFileName <- args[2]

data <- read.table(iFileName, header = TRUE, sep=",")
data <- data[complete.cases(data),]


mat <- data.matrix(data)

print(friedman.test(mat))

