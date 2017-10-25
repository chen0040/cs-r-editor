## ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~
## 						Notes to call this R script file
## 1. Make sure all input path, output path and source data exist before calling this R script file 
## 2. Navigate to the folder with R installed, eg. C:\Program Files\R\R-3.1.2\bin
## 3. Call RScript.exe D:/Project/RCode/Lactation_Parity1_Plot4.R D:/Project/Rcode Lactation_Parity1.csv D:/Project/RCode/Graphics Lactation_1stParity_Plot4.png
## 
## ~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

##First read in the arguments listed at the command line
args=(commandArgs(trailingOnly = TRUE))
if(length(args)<1){
	stop("No enough arguments supplied!")
}

iFileName <- args[1]
oFileName <- args[2]

LWdata <- read.table(iFileName, header = TRUE, sep=",")

LWdata <- LWdata[complete.cases(LWdata),]

head(LWdata)
summary(LWdata)

attach(LWdata)

##summary(Breed)
##  B    G    H    J    X 
##  10   10 8680 1120  680

##summary(Farm)
##  A   B   C   D   E   F   G   H   I   J   K   L   M   N   O   P   Q   R   S   T   U 
##500 500 500 500 500 500 500 500 500 500 500 500 500 500 500 500 500 500 500 500 500  

png(oFileName,width = 960, height = 960, units = "px", pointsize = 12) 

par(mfrow =c(2,2))

hist(as.numeric(milk), main = "Histogram of milk for lactation of 1st parity", xlab="milk yield")
plot( dim,  milk,main ="Milk yield vs day in milk color by Breed", xlab ="day in milk",ylab="milk yield", pch = 3, cex= 0.6,col= as.numeric(Breed))
plot( dim,  milk,main ="Milk yield vs day in milk color by Farm", xlab ="day in milk",ylab="milk yield", pch = 3, cex= 0.6,col= as.numeric(Farm))
plot( dim,  milk,main ="Milk yield vs day in milk color by month in milk", xlab ="day in milk",ylab="milk yield", pch = 3, cex= 0.6,col= as.numeric(monthinm))

detach(LWdata)

dev.off()