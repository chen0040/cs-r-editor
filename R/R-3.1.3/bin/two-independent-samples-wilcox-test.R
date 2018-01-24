## ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
## 						Notes to call this R script file
## 1. Make sure all input path, output path and source data exist before calling this R script file 
## 2. Navigate to the folder with R installed, eg. C:\Program Files\R\R-3.1.2\bin
## 3. Call RScript.exe D:/Project/RCode/Lactation_Parity1_Plot1.R D:/Project/Rcode Lactation_Parity1.csv D:/Project/RCode/Graphics Lactation_1stParity_Plot1.png
## 
## ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

##First read in the arguments listed at the command line
library(XML) 

args=(commandArgs(trailingOnly = TRUE))
if(length(args)<1){
	stop("No enough arguments supplied!")
}

iFileName <- args[1]
oFileName <- args[2]

data <- read.table(iFileName, header = TRUE, sep=",")
data <- data[complete.cases(data),]

# df <- data[c(1)]

top = newXMLNode("wilcox_test")

for(i in names(data)){
	x <- data[[i]]
	for(j in names(data)){
		y <- data[[j]]
		if(i != j) {
			# print(paste0("data x is ", i))
			# print(paste0("data y is ", j))
			case = newXMLNode("case", attrs=c(x=i, y=j), parent=top)
			tryCatch({
				# print(wilcox.test(x ~ y))
				chars <- capture.output(print(wilcox.test(x ~ y)))
				for(line in chars){
					newXMLNode("line", attrs=c(content=line), parent=case)
				}
			}, error = function(err){
				#print(paste0('error: ', err))
				newXMLNode("err", attrs=c(content=err), parent=case)
			})
			
		}
	}
}

print(top)
