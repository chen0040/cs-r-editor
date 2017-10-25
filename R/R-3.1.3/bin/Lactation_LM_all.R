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


# a * System.Math.Pow(t, b) * System.Math.Exp(-c * t)

#head(LWdata)

library(arm)

linear_model <- lm(milk ~ dim + dim2 + dim3, data=LWdata);

display(linear_model)
#str(linear_model)



png(oFileName, width = 960, height = 960, units = "px", pointsize = 12) 



tryCatch({
par(pch=22, col="gray") # plotting symbol and color 

LWdata <- LWdata[order(LWdata$dim),]

plot(LWdata$dim, LWdata$milk, type='p', xlab='DIM', ylab='Milk')
par(pch=22, col="blue") # plotting symbol and color 

new_dim <- seq(min(LWdata$dim), max(LWdata$dim), 5);
new_dim2 <- new_dim * new_dim
new_dim3 <- new_dim2 * new_dim
new <- data.frame(dim = new_dim, dim2 = new_dim2, dim3 = new_dim3)

lines(new_dim, predict(linear_model, new)) 
}, error=function(err){
print(err)
})

detach(LWdata)

print('test')

dev.off()





