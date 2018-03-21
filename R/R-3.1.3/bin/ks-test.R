library(XML) 

args=(commandArgs(trailingOnly = TRUE))
if(length(args)<1){
	stop("No enough arguments supplied!")
}

iFileName <- args[1]
oFileName <- args[2]

data <- read.table(iFileName, header = TRUE, sep=",")
data <- data[complete.cases(data),]
data <- data[c(1:2)]

print('Below is snapshot of the data submitted')
print(head(data, n = 5))

print('++++++++++++++++++++++++++++++++++++++++++++++')

# df <- data[c(1)]

for(i in names(data)){
	column1 <- data[[i]]

	
	for(j in names(data)){
		column2 <- data[[j]]
		
		if(i < j) {
			print(paste0('Below is a statistical summary of the column1 = ', i, ')'))
			print(summary(column1))
		
			print(paste0('Below is a statistical summary of the column2 = ', j, ')'))
			print(summary(column2))
	
			print('++++++++++++++++++++++++++++++++++++++++++++++')
			print('Below is the result from KS test')
			print(ks.test(column1, column2))
		}
	}
}



