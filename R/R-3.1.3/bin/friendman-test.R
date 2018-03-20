library(XML) 

args=(commandArgs(trailingOnly = TRUE))
if(length(args)<1){
	stop("No enough arguments supplied!")
}

iFileName <- args[1]
oFileName <- args[2]

data <- read.table(iFileName, header = TRUE, sep=",")
data <- data[complete.cases(data),]

print('Below is snapshot of the data submitted')
print(head(data, n = 5))

print('++++++++++++++++++++++++++++++++++++++++++++++')

print('Below is a statistical summary of the data submitted')
print(summary(data))



print('++++++++++++++++++++++++++++++++++++++++++++++')
print('Below is the result from Friedman test')

mat <- data.matrix(data)
print(friedman.test(mat))



