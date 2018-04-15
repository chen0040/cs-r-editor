args = commandArgs(trailingOnly = TRUE)

iFileName <- args[1]
oFileName <- args[2]
type <- "original"

if(length(args) >= 4){
	type <- args[3]
}

tryCatch({
	library(corrplot)

	M <- as.matrix(read.table(iFileName, sep=",", header=TRUE, , encoding="UTF-8"))

	corr <- cor(M)
	if (file.exists(oFileName)) file.remove(oFileName)

	png(filename=oFileName, width = 712, height = 690, units = "px")

	corrplot(corr, method="color", order=type)

	dev.off()
},
error=function(cond) {
	print(cond)
},
warning=function(cond) {
	print(cond)
})
