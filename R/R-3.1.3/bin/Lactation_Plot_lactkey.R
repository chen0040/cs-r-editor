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

lactkeys <- unique(unlist(LWdata[1], use.names = FALSE));

lactkey_count <- length(lactkeys)

row_count <- as.integer(ceiling(sqrt(lactkey_count)))

if(row_count < 1)
{
	row_count <- 1
}
else if(row_count > 5)
{
	row_count <- 5
}

par(mfrow=c(row_count,row_count)) # all plots on one page 

total_plot_count <- row_count * row_count
plot_count <- 0
for(lactkey in lactkeys)
{
	if(plot_count >= total_plot_count) break
	
	LWdataB <- LWdata[which(LWdata[1]==lactkey),]
	
	str(LWdataB)
		
	#par(pch=22, col="gray") # plotting symbol and color 
	plot(LWdataB$dim, LWdataB$milk, type='p', xlab='DIM', ylab='Milk', main=paste('lactkey = ', lactkey))	
	
	plot_count <- plot_count + 1
}


}, error=function(err){
print(err)
})

detach(LWdata)

print('test')

dev.off()





