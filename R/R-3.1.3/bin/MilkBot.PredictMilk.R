##~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~

args=(commandArgs(trailingOnly = TRUE))
if(length(args)<2){
	stop("No enough arguments supplied!")
}

inputpath <- args[3]

## set default values for the parameters
iFileName <- file.path(inputpath, "Lactation_WideData.csv")

print(iFileName)


stDay <-1
endDay <- 305
interval <- 7
#Max no of lactations in input files to load
maxLactation <- 100 ## if maxLactation == 0, it loads all lactations in the file

oFileName = paste("Lactation_Generated_", interval, ".csv", sep='')
oFileName = file.path(inputpath, oFileName)

print(oFileName)

srcData <- read.table(iFileName, header = TRUE, sep=",")

str(srcData)

MilkBot.PredDailyMilk <- function(aScale, bRamp,cOffset,decay,dim){
	dailyMilk <- aScale * exp (-decay * dim) * (1-exp ((cOffset - dim) /bRamp) /2 )
}

lactkeyCol <- c()
FarmCol<- c()
BreedCol<-c()
CalveDateCol <- c()
ParityCol <- numeric()
dimCol <- numeric()
milkCol<- numeric()



noofLactation  = nrow(srcData)

if (maxLactation !=0 & noofLactation> maxLactation ) noofLactation = maxLactation

cnt =0

## Generation
tryCatch(
{for (lac in 1:noofLactation ){
	dim = stDay

	 rowofLac <- as.matrix(srcData[lac,])

	 a = as.numeric(rowofLac[,"Scale"])
	 b = as.numeric(rowofLac[,"Ramp"])
	 c = as.numeric(rowofLac[,"Offset"])
	 d = as.numeric(rowofLac[,"Decay"])
	 
	 while (dim <= endDay)
	 {		
		##dailyMilk <- MilkBot.PredDailyMilk(a ,b,c,d,dim)
		dailyMilk <- a * exp (-d * dim) * (1-exp ((c - dim) /b) /2 )

		lactkeyCol <- c(lactkeyCol, rowofLac[,"lactkey"])
		FarmCol <- c(FarmCol, rowofLac[,"Farm"])
		BreedCol <- c(BreedCol, rowofLac[,"Breed"])
		CalveDateCol <- c(CalveDateCol, rowofLac[,"CalveDate"])
		ParityCol <- c(ParityCol, as.numeric(rowofLac[,"Parity"]))
		dimCol <- c(dimCol,dim)
		milkCol <- c(milkCol,dailyMilk )
		
		cnt = cnt +1
		dim <- dim +interval
		if (dim >endDay &  dim -interval <endDay) dim = endDay
	 } 
}
mydf <-data.frame(lactkey=lactkeyCol, Farm=FarmCol,Breed=BreedCol,CalveDate=CalveDateCol,Parity=ParityCol,dim=dimCol,milk=milkCol)

write.table(mydf, file = oFileName,row.names=FALSE, quote=FALSE, sep=",")
print (paste(noofLactation, " lactations in ",cnt," rows is successfully generated and saved in ",oFileName,sep=""))
}, 
error=function(err){
print(err)
}
)
