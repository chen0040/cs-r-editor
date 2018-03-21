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

for(i in names(data)){
	column1 <- data[[i]]
	print(paste0('Below is a statistical summary of the column ', i))
	print(summary(data[[i]]))
}


print('++++++++++++++++++++++++++++++++++++++++++++++')
print('Below is the result from Friedman test')

mat <- data.matrix(data)
print(friedman.test(mat))



