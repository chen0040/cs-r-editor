args=(commandArgs(trailingOnly = TRUE))
if(length(args)<2){
	stop("No enough arguments supplied!")
}

iFileName <- args[1]
oFileName <- args[2]

LWdata <- read.table(iFileName, header = TRUE, sep=",")

LWdata <- LWdata[complete.cases(LWdata),]

LWdata$dim2 <- LWdata$dim * LWdata$dim
LWdata$dim3 <- LWdata$dim2 * LWdata$dim

library(lme4)
library(arm)

model.1 <- lm(formula = milk ~ dim + dim2 + dim3, data = LWdata)
print('Model 1:')
display(model.1)
anova(model.1)
aic <- AIC(model.1)

model.2 <- lm(formula = milk ~ dim + dim2 + dim3 + Breed, data = LWdata)
print('Model 2:')
display(model.2)
anova(model.2)
aic <- AIC(model.2)

anova(model.1, model.2, test="F")

model.3 <- lm(formula = milk ~ Farm + Breed + Farm * Breed, data = LWdata)

png(oFileName, width = 960, height = 960, units = "px", pointsize = 12) 

tryCatch({

par(mfrow=c(3,3)) # all plots on one page 

plot(milk ~ Breed + Farm, data=LWdata, main='No box diff if Farm or Breed levels no effect', col = 'pink')

#plot(milk ~ Breed, col=rainbow(1)[levels(LWdata$Farm)], data=LWdata, main='Hierarchical anova')

interaction.plot(LWdata$Breed, LWdata$Farm, LWdata$milk, main='No Breed * Farm interaction if lines parallel', col='blue')

interaction.plot(LWdata$Farm, LWdata$Breed, LWdata$milk, main='No Breed * Farm interaction if lines parallel', col='blue')

qqnorm(model.3$res, main='Straight line if err normal distribution', col='orange')
qqline(model.3$res)
plot(model.3$fitted, model.3$res, xlab='Fitted', ylab='Residuals', main='Residual uniformly around 0 if err normal distribution', col='orange')




}, error=function(err){
print(err)
})

detach(LWdata)

dev.off()








