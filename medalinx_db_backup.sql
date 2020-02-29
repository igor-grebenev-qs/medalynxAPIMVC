-- MySQL dump 10.13  Distrib 8.0.19, for Linux (x86_64)
--
-- Host: 35.188.34.140    Database: medalynx_db2
-- ------------------------------------------------------
-- Server version	5.5.5-10.4.11-MariaDB-1:10.4.11+maria~bionic

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8mb4 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `AnalyticalApplications`
--

DROP TABLE IF EXISTS `AnalyticalApplications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `AnalyticalApplications` (
  `Id` varchar(38) NOT NULL,
  `Pos` int(11) NOT NULL DEFAULT 0,
  `Name` varchar(1024) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `AnalyticalApplications`
--

LOCK TABLES `AnalyticalApplications` WRITE;
/*!40000 ALTER TABLE `AnalyticalApplications` DISABLE KEYS */;
INSERT INTO `AnalyticalApplications` VALUES ('{01176d49-d602-46b3-bdee-ead758ccec07}',7,'BWA'),('{029352de-a17b-4ce0-b350-02702e67cf55}',2,'R Studio'),('{260aedf3-ce40-48d4-aa2e-8b7ee43cc192}',18,'Platypus'),('{2b1c7bb0-67bf-48f7-b0da-1dceec9e429d}',3,'Vcftools'),('{3ac5ecf4-7d42-44a9-8d70-1b104ba1066e}',15,'Knimev'),('{4bb13f4a-6481-4ac9-b8f3-275930d964ba}',8,'Bowtie'),('{4f31e556-9886-4a26-baf5-53d9defe4f6e}',16,'perl'),('{6b9a507e-3340-4d64-8fd9-908a69c00f6d}',1,'R'),('{73231c3a-e405-48e9-a6a0-c8197edb9513}',12,'Gvcftools'),('{732749ff-2a1a-43c7-94c7-9c11a04b0ff8}',5,'Samtools'),('{77478c17-b0d9-4f97-8c40-fc3d63e238d0}',10,'GATK'),('{78ccc45c-ef7a-4500-8056-6a32ba3d4979}',17,'Pickard'),('{9a10a5ec-5adb-46e0-897d-4f0619bc95da}',13,'ICG genome browser'),('{9ac8b41f-933e-4188-be8d-f4a5d81790d4}',9,'Python'),('{a3726509-f0f1-47a1-8d1c-01d6dbd3972b}',14,'Java'),('{b2c39a46-856a-43b5-98aa-37aaf881c641}',4,'Bcftools'),('{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}',0,'I will load my own applications'),('{d03e9edd-0b89-4423-bb0c-9a1882fe312b}',6,'Blast'),('{db38f8e1-fbb5-4a63-904b-ddbc576af70a}',11,'Gcc'),('{ecbf979e-0853-4801-bda3-a60b23015750}',19,'VEP (variant effect predictor)');
/*!40000 ALTER TABLE `AnalyticalApplications` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Biomarkers`
--

DROP TABLE IF EXISTS `Biomarkers`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Biomarkers` (
  `Id` varchar(38) NOT NULL,
  `DiseaseState` varchar(1024) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Biomarkers`
--

LOCK TABLES `Biomarkers` WRITE;
/*!40000 ALTER TABLE `Biomarkers` DISABLE KEYS */;
INSERT INTO `Biomarkers` VALUES ('{3399fdb9-f33c-4532-8fc4-cd370fde592e}','Progesterone'),('{74e05cd7-8b87-4b34-86a0-73cac65db1a5}','C-Reactive Protein'),('{7b1b6585-e9dd-4d17-9ef0-af179246e2b3}','Calcium'),('{92f64a21-6170-4019-8cc8-917ab7e8b4dd}','Absolute Monocytes	');
/*!40000 ALTER TABLE `Biomarkers` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `CohortEnumLink`
--

DROP TABLE IF EXISTS `CohortEnumLink`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `CohortEnumLink` (
  `Id` varchar(38) NOT NULL,
  `CohortId` varchar(38) NOT NULL,
  `CohortEnumId` varchar(38) NOT NULL,
  `EnumItemId` varchar(38) NOT NULL,
  `Include` int(11) DEFAULT 0,
  `Percentage` float DEFAULT NULL COMMENT 'Percentage match to the criteria grouped into bands',
  `CreationDate` datetime NOT NULL DEFAULT current_timestamp(),
  `LastUpdate` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `CohortEnumLink`
--

LOCK TABLES `CohortEnumLink` WRITE;
/*!40000 ALTER TABLE `CohortEnumLink` DISABLE KEYS */;
/*!40000 ALTER TABLE `CohortEnumLink` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `CohortEnums`
--

DROP TABLE IF EXISTS `CohortEnums`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `CohortEnums` (
  `Id` varchar(38) NOT NULL,
  `Name` varchar(1024) NOT NULL,
  `CreationDate` datetime NOT NULL DEFAULT current_timestamp(),
  `LastUpdate` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COMMENT='Cohort enums:\n  DeseaseStates\n  GeneticMatches\n  Biomarkers\n  Demographics\n  Ethnicitys\n  StageOfDeseases\n  Prognosis\n  PreviousTreatments';
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `CohortEnums`
--

LOCK TABLES `CohortEnums` WRITE;
/*!40000 ALTER TABLE `CohortEnums` DISABLE KEYS */;
INSERT INTO `CohortEnums` VALUES ('{152583bb-7105-462e-ad74-c9702696feae}','PreviousTreatments','2020-01-29 06:39:24','2020-01-29 06:39:24'),('{3089e988-cbaa-4417-9ff2-447a3d90a534}','DiseaseStates','2020-01-29 12:00:00','2020-01-29 12:00:00'),('{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','GeneticMatches','2020-01-29 06:39:22','2020-01-29 06:39:22'),('{47f7bac5-60e6-4161-86d9-4ec5f561cafa}','Demographics','2020-01-29 06:39:23','2020-01-29 06:39:23'),('{5d65643e-4060-48e3-a094-347133b0ed81}','Prognosis','2020-01-29 06:39:24','2020-01-29 06:39:24'),('{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','Biomarkers','2020-01-29 06:39:22','2020-01-29 06:39:22'),('{cc77ecca-8279-4c9d-b321-064ba492ba9e}','StageOfDiseases','2020-01-29 06:39:23','2020-01-29 06:39:23'),('{f1c60ef6-f4cc-45c6-9dc3-e53d9edc14c5}','Ethnicitys','2020-01-29 06:39:23','2020-01-29 06:39:23');
/*!40000 ALTER TABLE `CohortEnums` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Cohorts`
--

DROP TABLE IF EXISTS `Cohorts`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Cohorts` (
  `Id` varchar(38) NOT NULL COMMENT 'Guid',
  `ProjectId` varchar(38) NOT NULL DEFAULT '{00000000-0000-0000-0000-000000000000}',
  `NumberOfSubjectsRequired` int(11) DEFAULT 0,
  `CohortType` varchar(1024) DEFAULT NULL,
  `RequestAdmin` int(11) DEFAULT 0,
  `RequestUser` int(11) DEFAULT 0,
  `Status` int(11) NOT NULL DEFAULT 0,
  `RequestType` int(11) DEFAULT 0,
  `CreationDate` datetime NOT NULL DEFAULT current_timestamp(),
  `LastUpdate` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Cohorts`
--

LOCK TABLES `Cohorts` WRITE;
/*!40000 ALTER TABLE `Cohorts` DISABLE KEYS */;
/*!40000 ALTER TABLE `Cohorts` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Demographics`
--

DROP TABLE IF EXISTS `Demographics`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Demographics` (
  `Id` varchar(38) NOT NULL,
  `AgeFrom` float DEFAULT NULL,
  `AgeTo` float DEFAULT NULL,
  `Gender` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Demographics`
--

LOCK TABLES `Demographics` WRITE;
/*!40000 ALTER TABLE `Demographics` DISABLE KEYS */;
/*!40000 ALTER TABLE `Demographics` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `DiseaseStates`
--

DROP TABLE IF EXISTS `DiseaseStates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `DiseaseStates` (
  `Id` varchar(38) NOT NULL,
  `DiseaseState` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `DiseaseStates`
--

LOCK TABLES `DiseaseStates` WRITE;
/*!40000 ALTER TABLE `DiseaseStates` DISABLE KEYS */;
INSERT INTO `DiseaseStates` VALUES ('{2990b095-ad97-4144-a69f-b8007aa78ed3}','Salmonella septicaemia'),('{4047257e-ca3d-4b47-ac1d-9ff49801d388}','Localised Salmonella infections'),('{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}','Paratyphoid fever A'),('{f14840b5-46c2-46e8-a92c-f9b2dbc5dbd7}','Salmonella gastro-enteritis');
/*!40000 ALTER TABLE `DiseaseStates` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Environments`
--

DROP TABLE IF EXISTS `Environments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Environments` (
  `Id` varchar(38) NOT NULL,
  `ProjectId` varchar(38) NOT NULL,
  `NumberOfUsers` int(11) DEFAULT 0,
  `DataStorage` float DEFAULT 0 COMMENT 'Data strorage GB',
  `AnalyticalApplication` longtext NOT NULL COMMENT 'Array of analytical applications',
  `TypeOfConnectivity` varchar(38) DEFAULT '{00000000-0000-0000-0000-000000000000}',
  `Request` int(11) DEFAULT 0,
  `RequestType` int(11) DEFAULT 0,
  `Status` int(11) NOT NULL DEFAULT 0,
  `CreationDate` datetime NOT NULL DEFAULT current_timestamp(),
  `LastUpdate` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Environments`
--

LOCK TABLES `Environments` WRITE;
/*!40000 ALTER TABLE `Environments` DISABLE KEYS */;
/*!40000 ALTER TABLE `Environments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Ethnicitys`
--

DROP TABLE IF EXISTS `Ethnicitys`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Ethnicitys` (
  `Id` varchar(38) NOT NULL,
  `Nationality` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Ethnicitys`
--

LOCK TABLES `Ethnicitys` WRITE;
/*!40000 ALTER TABLE `Ethnicitys` DISABLE KEYS */;
INSERT INTO `Ethnicitys` VALUES ('{1b48b566-2323-4f84-9f13-311a189dbea7}','Hispanic or Latino');
/*!40000 ALTER TABLE `Ethnicitys` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `GeneticMatches`
--

DROP TABLE IF EXISTS `GeneticMatches`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `GeneticMatches` (
  `Id` varchar(38) NOT NULL,
  `Chromosome` varchar(1024) DEFAULT NULL,
  `Position` int(11) DEFAULT NULL,
  `Ref` varchar(1024) DEFAULT NULL,
  `Alt` varchar(1024) DEFAULT NULL,
  `dbSNP` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `GeneticMatches`
--

LOCK TABLES `GeneticMatches` WRITE;
/*!40000 ALTER TABLE `GeneticMatches` DISABLE KEYS */;
INSERT INTO `GeneticMatches` VALUES ('{1c308f58-c3e0-450d-91f4-9c5543129d42}','45',10862849,'D','L','rs3916640'),('{555babc2-3a1d-4025-b835-a8098945726c}','23',10862848,'C','F','rs3916649'),('{5f6617d5-1cd7-4606-8eee-5a7534a94001}','40',10862847,'B','H','rs3916648'),('{f132a112-030b-423e-a304-69748cad26d5}','5',10862846,'A','T','rs3916645');
/*!40000 ALTER TABLE `GeneticMatches` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `HistoryItems`
--

DROP TABLE IF EXISTS `HistoryItems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `HistoryItems` (
  `Id` varchar(38) NOT NULL,
  `UserId` varchar(38) NOT NULL,
  `ObjectId` varchar(38) NOT NULL,
  `ObjectType` varchar(1024) DEFAULT NULL,
  `Message` longtext DEFAULT NULL,
  `CreationDate` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `HistoryItems`
--

LOCK TABLES `HistoryItems` WRITE;
/*!40000 ALTER TABLE `HistoryItems` DISABLE KEYS */;
INSERT INTO `HistoryItems` VALUES ('{00f826bb-d6a1-44e5-82ba-68a24c9d6957}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','{2a681a36-d2ec-41c0-a45a-a6028b1d4048}','MedalynxAPI.Controllers.TeamController','Create team called with data: {\"Id\":\"{2a681a36-d2ec-41c0-a45a-a6028b1d4048}\",\"Name\":\"Default Team\",\"Details\":\"Autocreated\",\"CreationDate\":\"2020-02-28T08:23:19.0475217Z\",\"LastUpdate\":\"2020-02-28T08:23:19.0475217Z\"}','2020-02-28 08:23:22'),('{19315e74-cc75-4d85-a4cb-ff7d055ddfe8}','{57a98e8e-f5ab-4032-b647-b793b60468ff}','{9ae3dfe4-ae85-410d-8696-9427650d100a}','MedalynxAPI.Controllers.ProjectsController','Create project called with data: {\"Id\":\"{9ae3dfe4-ae85-410d-8696-9427650d100a}\",\"TeamId\":\"{8fe5eedf-47ee-44a8-918e-dc6d38a92dac}\",\"Name\":\"sample\",\"Access\":null,\"CreationDate\":\"2020-02-28T08:30:30.5191485Z\",\"LastUpdate\":\"2020-02-28T08:30:30.5191485Z\"}','2020-02-28 08:30:35'),('{4d2cb714-cd6e-48d9-9d11-8ff834535783}','n/a','{78c537fc-f0cb-4944-985d-62b3110a8f33}','MedalynxAPI.Models.Metadata','Patch applied: {29db4fa0-461a-425e-83fe-74889094adf8}','2020-02-29 02:56:53'),('{5586515d-0db6-4f70-98c3-2388e39eaa6c}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','{58b39ac1-9ddb-4f3f-b990-141c4d2b8a76}','MedalynxAPI.Controllers.TeamController','Create team called with data: {\"Id\":\"{58b39ac1-9ddb-4f3f-b990-141c4d2b8a76}\",\"Name\":\"Default Team\",\"Details\":\"Autocreated\",\"CreationDate\":\"2020-02-28T08:29:02.7022156Z\",\"LastUpdate\":\"2020-02-28T08:29:02.7022156Z\"}','2020-02-28 08:29:05'),('{585ae069-b5d7-4e67-adb6-7aaf4dae1036}','{57a98e8e-f5ab-4032-b647-b793b60468ff}','{5bdc8892-14b5-42e2-9930-3cda1c5890ca}','MedalynxAPI.TeamDBAPI','User added to team with id: {8fe5eedf-47ee-44a8-918e-dc6d38a92dac} <- ({57a98e8e-f5ab-4032-b647-b793b60468ff})','2020-02-28 08:30:32'),('{734979ed-2630-497e-8699-b103d4fee337}','n/a','{3e97303c-1dda-4f2b-a2dd-f3b101f573c0}','MedalynxAPI.Models.Metadata','Patch applied: {8707c7bf-9748-4634-bb0a-af151c6fd399}','2020-02-29 04:56:18'),('{7ba41368-8371-45fd-b265-85f059c13828}','{57a98e8e-f5ab-4032-b647-b793b60468ff}','{8fe5eedf-47ee-44a8-918e-dc6d38a92dac}','MedalynxAPI.Controllers.TeamController','Create team called with data: {\"Id\":\"{8fe5eedf-47ee-44a8-918e-dc6d38a92dac}\",\"Name\":\"Default Team\",\"Details\":\"Autocreated\",\"CreationDate\":\"2020-02-28T08:30:30.5208189Z\",\"LastUpdate\":\"2020-02-28T08:30:30.5208189Z\"}','2020-02-28 08:30:33'),('{8bfef667-e778-429b-9f59-aaaf2d844d53}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','{5e97aff4-a95c-4df4-8621-6b15841fe2bf}','MedalynxAPI.TeamDBAPI','User added to team with id: {58b39ac1-9ddb-4f3f-b990-141c4d2b8a76} <- ({574e9d57-24fa-4a65-b1dd-ff7b742d18f2})','2020-02-28 08:29:04'),('{938a3e71-aeef-44b3-881c-8bba48059c7b}','n/a','{de35e58f-851a-4362-93fc-2fb84d7c6be0}','MedalynxAPI.Models.Metadata','Patch applied: {29d8be4e-394f-4c28-888d-cd6f5811951a}','2020-02-27 04:09:24'),('{b42f1a99-fa33-48c6-87c3-43c46d37d71a}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','{66de9822-78a3-460f-abb3-39e27ec8fb9c}','MedalynxAPI.Controllers.ProjectsController','Create project called with data: {\"Id\":\"{66de9822-78a3-460f-abb3-39e27ec8fb9c}\",\"TeamId\":\"{58b39ac1-9ddb-4f3f-b990-141c4d2b8a76}\",\"Name\":\"sample project\",\"Access\":\"DEFAULT\",\"CreationDate\":\"2020-02-28T08:29:02.7011054Z\",\"LastUpdate\":\"2020-02-28T08:29:02.7011054Z\"}','2020-02-28 08:29:07'),('{b9771cb1-5aec-47c3-a387-5b2ed20e0a6c}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','{c90f5f74-0871-4cd8-8c0a-38d4458a0fce}','MedalynxAPI.TeamDBAPI','User added to team with id: {2a681a36-d2ec-41c0-a45a-a6028b1d4048} <- ({574e9d57-24fa-4a65-b1dd-ff7b742d18f2})','2020-02-28 08:23:21'),('{c6616e05-1ae3-414c-81b1-102a2ee6e44e}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','{e1838fc5-fe88-493a-b2ef-f25cba63cc77}','MedalynxAPI.Controllers.ProjectsController','Create project called with data: {\"Id\":\"{e1838fc5-fe88-493a-b2ef-f25cba63cc77}\",\"TeamId\":\"{2a681a36-d2ec-41c0-a45a-a6028b1d4048}\",\"Name\":\"sample project\",\"Access\":\"DEFAULT\",\"CreationDate\":\"2020-02-28T08:23:19.0458983Z\",\"LastUpdate\":\"2020-02-28T08:23:19.0458983Z\"}','2020-02-28 08:23:23'),('{ed277850-ada1-452b-a47a-7e38f360268a}','n/a','{a42e9c5e-cd79-4b45-b513-7192c7e8d740}','MedalynxAPI.Models.Metadata','Patch applied: {c1ccca5f-00df-4d63-ba38-e55b1ba94dfa}','2020-02-29 04:01:10');
/*!40000 ALTER TABLE `HistoryItems` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Messages`
--

DROP TABLE IF EXISTS `Messages`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Messages` (
  `Id` varchar(38) NOT NULL,
  `UserId` varchar(38) DEFAULT NULL,
  `MessageBody` longtext DEFAULT NULL,
  `CreationDate` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Messages`
--

LOCK TABLES `Messages` WRITE;
/*!40000 ALTER TABLE `Messages` DISABLE KEYS */;
/*!40000 ALTER TABLE `Messages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Metadata`
--

DROP TABLE IF EXISTS `Metadata`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Metadata` (
  `Id` varchar(38) NOT NULL,
  `MetadataOrder` int(11) NOT NULL DEFAULT 0,
  `Comment` varchar(1024) DEFAULT NULL,
  `Data` longtext DEFAULT NULL,
  `CreationDate` datetime NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Metadata`
--

LOCK TABLES `Metadata` WRITE;
/*!40000 ALTER TABLE `Metadata` DISABLE KEYS */;
INSERT INTO `Metadata` VALUES ('{3e97303c-1dda-4f2b-a2dd-f3b101f573c0}',4,'Patch applied: {8707c7bf-9748-4634-bb0a-af151c6fd399}','ALTER TABLE `medalynx_db2`.`Notifications` \nADD COLUMN `Request` INT NULL DEFAULT 0 AFTER `Processing`,\nCHANGE COLUMN `Status` `Status` INT(11) NULL DEFAULT 0 COMMENT \'Created = 0, Read = 1, Cancelld = 2\\\\n\' ;','2020-02-29 04:56:17'),('{78c537fc-f0cb-4944-985d-62b3110a8f33}',2,'Patch applied: {29db4fa0-461a-425e-83fe-74889094adf8}','ALTER TABLE `medalynx_db2`.`Notifications` \n\nADD COLUMN `Processing` INT NULL DEFAULT 0 AFTER `Status`;','2020-02-29 02:56:51'),('{a42e9c5e-cd79-4b45-b513-7192c7e8d740}',3,'Patch applied: {c1ccca5f-00df-4d63-ba38-e55b1ba94dfa}','ALTER TABLE `medalynx_db2`.`Notifications` \n\nADD COLUMN `RequestType` INT NULL DEFAULT 0 AFTER `Status`;','2020-02-29 04:01:09'),('{de35e58f-851a-4362-93fc-2fb84d7c6be0}',1,'Patch applied: {29d8be4e-394f-4c28-888d-cd6f5811951a}','CREATE TABLE medalynx_db2.test_table ( f1 INT NOT NULL );\n\nALTER TABLE medalynx_db2.test_table ADD f2 INT NOT NULL DEFAULT 0 AFTER f1;\n','2020-02-27 04:09:23');
/*!40000 ALTER TABLE `Metadata` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Notifications`
--

DROP TABLE IF EXISTS `Notifications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Notifications` (
  `Id` varchar(38) NOT NULL,
  `UserId` varchar(38) DEFAULT NULL,
  `ProjectId` varchar(38) NOT NULL,
  `Message` longtext DEFAULT NULL,
  `NotificationType` int(11) NOT NULL COMMENT 'Environment, Cohort, Pharma user etc',
  `Status` int(11) DEFAULT 0 COMMENT 'Created = 0, Read = 1, Cancelld = 2\\n',
  `RequestType` int(11) DEFAULT 0,
  `Processing` int(11) DEFAULT 0,
  `Request` int(11) DEFAULT 0,
  `CreationDate` datetime NOT NULL DEFAULT current_timestamp(),
  `LastUpdate` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Notifications`
--

LOCK TABLES `Notifications` WRITE;
/*!40000 ALTER TABLE `Notifications` DISABLE KEYS */;
/*!40000 ALTER TABLE `Notifications` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `PreviousTreatments`
--

DROP TABLE IF EXISTS `PreviousTreatments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `PreviousTreatments` (
  `Id` varchar(38) NOT NULL,
  `Keyword` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `PreviousTreatments`
--

LOCK TABLES `PreviousTreatments` WRITE;
/*!40000 ALTER TABLE `PreviousTreatments` DISABLE KEYS */;
INSERT INTO `PreviousTreatments` VALUES ('{0eb27144-8c1c-4ad6-a513-ce109fc735ec}','Mortin');
/*!40000 ALTER TABLE `PreviousTreatments` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Prognosis`
--

DROP TABLE IF EXISTS `Prognosis`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Prognosis` (
  `Id` varchar(38) NOT NULL,
  `Keyword` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Prognosis`
--

LOCK TABLES `Prognosis` WRITE;
/*!40000 ALTER TABLE `Prognosis` DISABLE KEYS */;
INSERT INTO `Prognosis` VALUES ('{3eb9d916-1a66-495d-9ba9-3f28f4510daf}','Tumor');
/*!40000 ALTER TABLE `Prognosis` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Project`
--

DROP TABLE IF EXISTS `Project`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Project` (
  `Id` varchar(38) NOT NULL,
  `TeamId` varchar(38) NOT NULL,
  `Name` varchar(1024) DEFAULT NULL,
  `Access` varchar(255) DEFAULT NULL,
  `CreationDate` datetime NOT NULL DEFAULT current_timestamp(),
  `LastUpdate` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`Id`,`TeamId`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Project`
--

LOCK TABLES `Project` WRITE;
/*!40000 ALTER TABLE `Project` DISABLE KEYS */;
INSERT INTO `Project` VALUES ('{66de9822-78a3-460f-abb3-39e27ec8fb9c}','{58b39ac1-9ddb-4f3f-b990-141c4d2b8a76}','sample project','DEFAULT','2020-02-28 08:29:02','2020-02-28 08:29:02'),('{9ae3dfe4-ae85-410d-8696-9427650d100a}','{8fe5eedf-47ee-44a8-918e-dc6d38a92dac}','sample',NULL,'2020-02-28 08:30:30','2020-02-28 08:30:30'),('{e1838fc5-fe88-493a-b2ef-f25cba63cc77}','{2a681a36-d2ec-41c0-a45a-a6028b1d4048}','sample project','DEFAULT','2020-02-28 08:23:19','2020-02-28 08:23:19');
/*!40000 ALTER TABLE `Project` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Sessions`
--

DROP TABLE IF EXISTS `Sessions`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Sessions` (
  `Id` varchar(38) NOT NULL,
  `UserId` varchar(38) NOT NULL,
  `CreationDate` datetime NOT NULL DEFAULT current_timestamp(),
  `LastUpdate` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Sessions`
--

LOCK TABLES `Sessions` WRITE;
/*!40000 ALTER TABLE `Sessions` DISABLE KEYS */;
INSERT INTO `Sessions` VALUES ('{98c41a14-2e6a-4e43-8652-753bb27e9adc}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','2020-02-19 07:35:16','2020-02-19 07:35:16'),('{abeaf964-4d59-4cf7-af40-6260dac2d4dd}','{bde09723-429a-4d20-a0e1-ab1672936243}','2020-02-25 09:56:01','2020-02-25 09:56:01'),('{f3ad5423-bc55-4863-b24a-3aa13ff8f25e}','{57a98e8e-f5ab-4032-b647-b793b60468ff}','2020-02-25 11:22:56','2020-02-25 11:22:56');
/*!40000 ALTER TABLE `Sessions` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `StageOfDiseases`
--

DROP TABLE IF EXISTS `StageOfDiseases`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `StageOfDiseases` (
  `Id` varchar(38) NOT NULL,
  `StageOfTumour` int(11) DEFAULT NULL,
  `NumberOfNodesAffected` int(11) DEFAULT NULL,
  `NumberOfMetastasis` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `StageOfDiseases`
--

LOCK TABLES `StageOfDiseases` WRITE;
/*!40000 ALTER TABLE `StageOfDiseases` DISABLE KEYS */;
INSERT INTO `StageOfDiseases` VALUES ('{089af994-0991-4e4a-bb0b-fac5c91450c0}',1,2,3);
/*!40000 ALTER TABLE `StageOfDiseases` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Team`
--

DROP TABLE IF EXISTS `Team`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Team` (
  `Id` varchar(38) NOT NULL,
  `Name` varchar(1024) DEFAULT NULL,
  `Details` longtext DEFAULT NULL,
  `CreationDate` datetime NOT NULL DEFAULT current_timestamp(),
  `LastUpdate` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Team`
--

LOCK TABLES `Team` WRITE;
/*!40000 ALTER TABLE `Team` DISABLE KEYS */;
INSERT INTO `Team` VALUES ('{2a681a36-d2ec-41c0-a45a-a6028b1d4048}','Default Team','Autocreated','2020-02-28 08:23:19','2020-02-28 08:23:19'),('{58b39ac1-9ddb-4f3f-b990-141c4d2b8a76}','Default Team','Autocreated','2020-02-28 08:29:02','2020-02-28 08:29:02'),('{8fe5eedf-47ee-44a8-918e-dc6d38a92dac}','Default Team','Autocreated','2020-02-28 08:30:30','2020-02-28 08:30:30');
/*!40000 ALTER TABLE `Team` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TeamUserLink`
--

DROP TABLE IF EXISTS `TeamUserLink`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `TeamUserLink` (
  `Id` varchar(38) NOT NULL,
  `TeamId` varchar(38) NOT NULL,
  `UserId` varchar(38) NOT NULL,
  `AccessRights` varchar(255) DEFAULT 'DEFAULT',
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TeamUserLink`
--

LOCK TABLES `TeamUserLink` WRITE;
/*!40000 ALTER TABLE `TeamUserLink` DISABLE KEYS */;
INSERT INTO `TeamUserLink` VALUES ('{5bdc8892-14b5-42e2-9930-3cda1c5890ca}','{8fe5eedf-47ee-44a8-918e-dc6d38a92dac}','{57a98e8e-f5ab-4032-b647-b793b60468ff}','OWNER'),('{5e97aff4-a95c-4df4-8621-6b15841fe2bf}','{58b39ac1-9ddb-4f3f-b990-141c4d2b8a76}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','OWNER'),('{c90f5f74-0871-4cd8-8c0a-38d4458a0fce}','{2a681a36-d2ec-41c0-a45a-a6028b1d4048}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','OWNER');
/*!40000 ALTER TABLE `TeamUserLink` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `TypeOfConnectivity`
--

DROP TABLE IF EXISTS `TypeOfConnectivity`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `TypeOfConnectivity` (
  `Id` varchar(38) NOT NULL,
  `Pos` int(11) NOT NULL DEFAULT 0,
  `Name` varchar(1024) NOT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `TypeOfConnectivity`
--

LOCK TABLES `TypeOfConnectivity` WRITE;
/*!40000 ALTER TABLE `TypeOfConnectivity` DISABLE KEYS */;
INSERT INTO `TypeOfConnectivity` VALUES ('{2f3ff4f0-b363-40ba-990d-7b80f0df574f}',0,'Broadband'),('{724b466c-789f-4d85-8a33-cf1136f662a0}',2,'Direct Network'),('{c20cce93-c3d0-4ecb-8df7-7dedbaf34acf}',1,'Virtual Private Network (VPN)');
/*!40000 ALTER TABLE `TypeOfConnectivity` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Users`
--

DROP TABLE IF EXISTS `Users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Users` (
  `Id` varchar(38) COLLATE utf8_unicode_ci NOT NULL COMMENT 'Guid',
  `Email` varchar(1024) COLLATE utf8_unicode_ci NOT NULL,
  `FirstName` varchar(1024) COLLATE utf8_unicode_ci DEFAULT NULL,
  `LastName` varchar(1024) COLLATE utf8_unicode_ci DEFAULT NULL,
  `CompanyName` varchar(1024) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Request` int(11) DEFAULT 0 COMMENT '0 - created\n1 - accepted\n2 - rejected',
  `Password` varchar(38) COLLATE utf8_unicode_ci DEFAULT NULL COMMENT 'MD5 hash',
  `Role` varchar(45) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'STANDARD_USER',
  `Status` int(11) NOT NULL DEFAULT 0,
  `CreationDate` datetime NOT NULL DEFAULT current_timestamp(),
  `LastUpdate` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`Id`),
  UNIQUE KEY `Email` (`Email`)
) ENGINE=InnoDB DEFAULT CHARSET=utf8 COLLATE=utf8_unicode_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Users`
--

LOCK TABLES `Users` WRITE;
/*!40000 ALTER TABLE `Users` DISABLE KEYS */;
INSERT INTO `Users` VALUES ('{39c42f7e-c446-4416-b007-c40fdb5ef598}','dmitry.kochergin+demo@quantumsoft.pro','Dmitry','Kochergin','QuantumSoft',0,'{aef2cd61-a94e-0c7c-29cf-08c317991dea}','STANDARD_USER',0,'2020-02-17 15:05:59','2020-02-17 15:05:59'),('{49fffec7-48e4-4bbf-83b8-ee85e97051c5}','test4@mail.ru','testname','test','',0,'{aef2cd61-a94e-0c7c-29cf-08c317991dea}','STANDARD_USER',0,'2020-02-12 10:07:33','2020-02-12 10:07:33'),('{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','igor.ge@mail.ru','Igor (TEST USER)','Grebenev','Quantumsoft',0,'{aef2cd61-a94e-0c7c-29cf-08c317991dea}','STANDARD_USER',0,'2020-01-30 10:15:46','2020-01-30 10:15:46'),('{57a98e8e-f5ab-4032-b647-b793b60468ff}','medalynx@gmail.com','Admin','','',0,'{aef2cd61-a94e-0c7c-29cf-08c317991dea}','ADMIN',0,'2020-02-05 01:57:22','2020-02-05 01:57:22'),('{756f72f3-5150-4e85-b02a-a3f0ab23e07e}','test3@mail.ru','super','user','test',0,'{aef2cd61-a94e-0c7c-29cf-08c317991dea}','STANDARD_USER',0,'2020-02-12 10:01:21','2020-02-12 10:01:21'),('{aadc41b9-84a4-4d01-aec5-ffa982cdd1e5}','vasiliy.sokolov@quantumsoft.pro','Vasiliy','Sokolov','QuantumSoft',0,'{aef2cd61-a94e-0c7c-29cf-08c317991dea}','STANDARD_USER',0,'2020-02-17 12:23:38','2020-02-17 12:23:38'),('{ae999fda-46fb-42ef-b238-55cbf4b21ff8}','vasiliy.sokolov+demo1@quantumsoft.pro','Vasily','Sokolov','QuantumSoft',0,'{aef2cd61-a94e-0c7c-29cf-08c317991dea}','STANDARD_USER',0,'2020-02-17 14:54:25','2020-02-17 14:54:25'),('{b3643e06-bd3a-4429-aacb-89a52f8f7950}','antony@mail.ru','antony','antony','antony corporation',0,'{aef2cd61-a94e-0c7c-29cf-08c317991dea}','STANDARD_USER',0,'2020-02-10 06:02:57','2020-02-10 06:02:57'),('{bde09723-429a-4d20-a0e1-ab1672936243}','test1@mail.ru','antony','antony','antony',0,'{aef2cd61-a94e-0c7c-29cf-08c317991dea}','STANDARD_USER',0,'2020-02-12 09:59:01','2020-02-12 09:59:01'),('{bffe1e64-4c5b-435b-be7b-71585dab06fd}','testdev@mail.ru','test','dev','company',0,'{aef2cd61-a94e-0c7c-29cf-08c317991dea}','STANDARD_USER',0,'2020-02-18 05:56:11','2020-02-18 05:56:11'),('{c2e3ff31-eeb6-40d1-9cbf-f92153dc427c}','dmitry.kochergin@quantumsoft.pro','Dmitry','Kochergin','QS',0,'{aef2cd61-a94e-0c7c-29cf-08c317991dea}','STANDARD_USER',0,'2020-02-17 12:12:03','2020-02-17 12:12:03'),('{db909a00-49a4-4107-9066-7b02af48fd11}','vasiliy.sokolov+demo@quantumsoft.pro','Vasiliy','Sokolov','QuantumSoft',0,'{aef2cd61-a94e-0c7c-29cf-08c317991dea}','STANDARD_USER',0,'2020-02-17 14:08:51','2020-02-17 14:08:51'),('{e38fe985-af6e-4b21-a719-547b7462afe8}','testdev2@mail.ru','test','user','company',0,'{aef2cd61-a94e-0c7c-29cf-08c317991dea}','STANDARD_USER',0,'2020-02-18 07:19:05','2020-02-18 07:19:05'),('{e8d62dd6-59d4-4029-a1b1-248da6f933e4}','test@mail.ru','test','test','adf',0,'{aef2cd61-a94e-0c7c-29cf-08c317991dea}','STANDARD_USER',0,'2020-02-14 07:48:51','2020-02-14 07:48:51'),('{f62a2c71-77db-4166-bad8-5ff2676ac21b}','test2@mail.ru','user','test','test',0,'{aef2cd61-a94e-0c7c-29cf-08c317991dea}','STANDARD_USER',0,'2020-02-12 10:00:16','2020-02-12 10:00:16');
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `test_table`
--

DROP TABLE IF EXISTS `test_table`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `test_table` (
  `f1` int(11) NOT NULL,
  `f2` int(11) NOT NULL DEFAULT 0
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `test_table`
--

LOCK TABLES `test_table` WRITE;
/*!40000 ALTER TABLE `test_table` DISABLE KEYS */;
/*!40000 ALTER TABLE `test_table` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-02-29 12:08:40
