-- MySQL dump 10.13  Distrib 8.0.19, for Linux (x86_64)
--
-- Host: 35.188.34.140    Database: medalynx_db
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
  `DeseaseState` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Biomarkers`
--

LOCK TABLES `Biomarkers` WRITE;
/*!40000 ALTER TABLE `Biomarkers` DISABLE KEYS */;
INSERT INTO `Biomarkers` VALUES ('{3399fdb9-f33c-4532-8fc4-cd370fde592e}','Progesterone'),('{7b1b6585-e9dd-4d17-9ef0-af179246e2b3}','Calcium'),('{7f93db44-b29a-4039-a836-e713044d444c}','C-Reactive Protein'),('{92f64a21-6170-4019-8cc8-917ab7e8b4dd}','Absolute Monocytes	');
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
  `EnumItemId` varchar(38) DEFAULT NULL,
  `Include` int(11) DEFAULT 0,
  `Percentage` float DEFAULT NULL COMMENT 'Percentage match to the criteria grouped into bands',
  `NumberOfSubjects` int(11) DEFAULT NULL COMMENT 'Number of subjects matching the criteria',
  `Rate` float DEFAULT NULL COMMENT 'Rate of growth of the subject base matching the inclusion criteria',
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
INSERT INTO `CohortEnumLink` VALUES ('{14687e91-fd7f-47d2-b86e-63288839db26}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{3399fdb9-f33c-4532-8fc4-cd370fde592e}',0,0,0,0,'2020-01-30 08:27:56','2020-01-30 08:27:56'),('{1752eda0-5614-467b-8f7f-9af0c883b073}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{152583bb-7105-462e-ad74-c9702696feae}','{94c14b9a-0cec-4c86-8a7d-53fb17ead9b8}',0,0,0,0,'2020-01-30 08:27:53','2020-01-30 08:27:53'),('{2e7e812a-a67f-4903-b3ea-885e4335de89}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{47f7bac5-60e6-4161-86d9-4ec5f561cafa}','{c2474a7f-16db-4bc9-b7f4-915f4baadd48}',0,0,0,0,'2020-01-30 08:27:54','2020-01-30 08:27:54'),('{2fa1f449-5d58-443e-adcf-e066b34e181e}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{b784b009-20e8-43c7-9251-5593e1183484}',0,0,0,0,'2020-01-30 08:27:54','2020-01-30 08:27:54'),('{36e22b1a-a13f-4bd0-a2bf-e0d115c358ec}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{cace0279-ad76-4529-bc2e-58078c665bdb}',0,0,0,0,'2020-01-30 08:27:53','2020-01-30 08:27:53'),('{648a8f87-c7a8-4034-ad62-55dbe8499555}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{7b1b6585-e9dd-4d17-9ef0-af179246e2b3}',0,0,0,0,'2020-01-30 08:27:56','2020-01-30 08:27:56'),('{6a018d0c-d144-41e2-b501-b44aeca9bc25}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{5d65643e-4060-48e3-a094-347133b0ed81}','{e869be57-0400-4c55-9d6d-911e5af0a51f}',0,0,0,0,'2020-01-30 08:27:55','2020-01-30 08:27:55'),('{79bc2713-60ac-46e2-8dce-1f6fdc136a94}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{f132a112-030b-423e-a304-69748cad26d5}',0,0,0,0,'2020-01-30 08:27:54','2020-01-30 08:27:54'),('{7db84c08-f6b4-4387-9a03-0c91d298f6fe}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{f1c60ef6-f4cc-45c6-9dc3-e53d9edc14c5}','{1b48b566-2323-4f84-9f13-311a189dbea7}',0,0,0,0,'2020-01-30 08:27:57','2020-01-30 08:27:57'),('{91d71a08-4083-405e-908c-7dc6bf7adbab}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{555babc2-3a1d-4025-b835-a8098945726c}',0,0,0,0,'2020-01-30 08:27:54','2020-01-30 08:27:54'),('{936cdbeb-e73d-4df6-8867-cc94e47a7239}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{92f64a21-6170-4019-8cc8-917ab7e8b4dd}',0,0,0,0,'2020-01-30 08:27:56','2020-01-30 08:27:56'),('{98621b0c-3b5e-4f13-95c3-da5415bf9fda}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{cc77ecca-8279-4c9d-b321-064ba492ba9e}','{42511681-3320-4b70-8c8a-7b41a62edf07}',0,0,0,0,'2020-01-30 08:27:56','2020-01-30 08:27:56'),('{c0e2bd40-c364-4633-bac8-a16aad230a34}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{47f7bac5-60e6-4161-86d9-4ec5f561cafa}','{acb0eeeb-e141-4e34-8177-274fd392a39d}',0,0,0,0,'2020-01-30 08:27:54','2020-01-30 08:27:54'),('{c4c6f605-588f-4415-b249-b7ffa29e3877}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{7f93db44-b29a-4039-a836-e713044d444c}',0,0,0,0,'2020-01-30 08:27:56','2020-01-30 08:27:56'),('{c9ede3ed-bd40-4cd8-b26a-5ae75d7086ac}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{f14840b5-46c2-46e8-a92c-f9b2dbc5dbd7}',0,0,0,0,'2020-01-30 08:27:53','2020-01-30 08:27:53'),('{d98c7cb0-d9b9-4abf-93c2-e4d0c525fed0}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{a6b6e490-4d92-4f0b-8352-3fd8a1e8d268}',0,0,0,0,'2020-01-30 08:27:54','2020-01-30 08:27:54'),('{e89da75a-1923-478b-b2ce-8b0ccf1d9ea4}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{4f57817f-3113-4f2f-9617-ca881061df2b}',0,0,0,0,'2020-01-30 08:27:53','2020-01-30 08:27:53'),('{ea3640e5-f4fb-4422-b62a-2ee30a8fd52b}','{fc6ce350-bdac-4f47-b196-68016b848c5f}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}',0,0,0,0,'2020-01-30 08:27:53','2020-01-30 08:27:53');
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
  `Name` varchar(1024) DEFAULT NULL,
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
INSERT INTO `CohortEnums` VALUES ('{152583bb-7105-462e-ad74-c9702696feae}','PreviousTreatments','2020-01-29 06:39:24','2020-01-29 06:39:24'),('{3089e988-cbaa-4417-9ff2-447a3d90a534}','DeseaseStates','2020-01-29 12:00:00','2020-01-29 12:00:00'),('{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','GeneticMatches','2020-01-29 06:39:22','2020-01-29 06:39:22'),('{47f7bac5-60e6-4161-86d9-4ec5f561cafa}','Demographics','2020-01-29 06:39:23','2020-01-29 06:39:23'),('{5d65643e-4060-48e3-a094-347133b0ed81}','Prognosis','2020-01-29 06:39:24','2020-01-29 06:39:24'),('{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','Biomarkers','2020-01-29 06:39:22','2020-01-29 06:39:22'),('{cc77ecca-8279-4c9d-b321-064ba492ba9e}','StageOfDeseases','2020-01-29 06:39:23','2020-01-29 06:39:23'),('{f1c60ef6-f4cc-45c6-9dc3-e53d9edc14c5}','Ethnicitys','2020-01-29 06:39:23','2020-01-29 06:39:23');
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
  `UserId` varchar(38) NOT NULL DEFAULT '{00000000-0000-0000-0000-000000000000}',
  `NumberOfSubjectsRequired` int(11) DEFAULT 0,
  `CohortType` varchar(1024) DEFAULT NULL,
  `Request` int(11) DEFAULT 0,
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
INSERT INTO `Cohorts` VALUES ('{fc6ce350-bdac-4f47-b196-68016b848c5f}','{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}',1,'unknown',1,'2020-01-30 08:27:47','2020-01-30 08:27:47');
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
  `Age` varchar(1024) DEFAULT NULL,
  `Gender` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Demographics`
--

LOCK TABLES `Demographics` WRITE;
/*!40000 ALTER TABLE `Demographics` DISABLE KEYS */;
INSERT INTO `Demographics` VALUES ('{acb0eeeb-e141-4e34-8177-274fd392a39d}','25-27','Female'),('{c2474a7f-16db-4bc9-b7f4-915f4baadd48}','18-24','Male');
/*!40000 ALTER TABLE `Demographics` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `DeseaseStates`
--

DROP TABLE IF EXISTS `DeseaseStates`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `DeseaseStates` (
  `Id` varchar(38) NOT NULL,
  `DeseaseState` varchar(1024) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `DeseaseStates`
--

LOCK TABLES `DeseaseStates` WRITE;
/*!40000 ALTER TABLE `DeseaseStates` DISABLE KEYS */;
INSERT INTO `DeseaseStates` VALUES ('{4f57817f-3113-4f2f-9617-ca881061df2b}','Localised Salmonella infections'),('{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}','Paratyphoid fever A'),('{cace0279-ad76-4529-bc2e-58078c665bdb}','Salmonella septicaemia'),('{f14840b5-46c2-46e8-a92c-f9b2dbc5dbd7}','Salmonella gastro-enteritis');
/*!40000 ALTER TABLE `DeseaseStates` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Enviroments`
--

DROP TABLE IF EXISTS `Enviroments`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Enviroments` (
  `Id` varchar(38) NOT NULL,
  `UserId` varchar(38) NOT NULL,
  `NumberOfUsers` int(11) DEFAULT 0,
  `DataStorage` float DEFAULT 0 COMMENT 'Data strorage GB',
  `AnalyticalApplication` longtext NOT NULL DEFAULT '[]' COMMENT 'Array of analytical applications',
  `TypeOfConnectivity` varchar(38) DEFAULT '{00000000-0000-0000-0000-000000000000}',
  `Request` int(11) DEFAULT NULL,
  `CreationDate` datetime NOT NULL DEFAULT current_timestamp(),
  `LastUpdate` datetime NOT NULL DEFAULT current_timestamp(),
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `Enviroments`
--

LOCK TABLES `Enviroments` WRITE;
/*!40000 ALTER TABLE `Enviroments` DISABLE KEYS */;
INSERT INTO `Enviroments` VALUES ('{5b890fcd-7017-4474-89c8-6ba3810868f2}','{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}',10,100,'[]','{2f3ff4f0-b363-40ba-990d-7b80f0df574f}',0,'2020-01-31 05:25:01','2020-01-31 05:28:07'),('{9787dda9-0d30-47fd-b3c7-3cff398cad0f}','',120,1,'[\"{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\",\"{ecbf979e-0853-4801-bda3-a60b23015750}\"]','{2f3ff4f0-b363-40ba-990d-7b80f0df574f}',2,'2020-01-31 06:23:13','2020-01-31 06:23:13'),('{9a053a72-49e0-42b8-a51c-db59895caeda}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}',1,1,'[\"{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\",\"{9ac8b41f-933e-4188-be8d-f4a5d81790d4}\",\"{ecbf979e-0853-4801-bda3-a60b23015750}\",\"{77478c17-b0d9-4f97-8c40-fc3d63e238d0}\"]','{c20cce93-c3d0-4ecb-8df7-7dedbaf34acf}',2,'2020-01-31 06:23:20','2020-01-31 06:23:20'),('{aa42028e-7120-4c7a-ae3d-77dac8bb1c5b}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}',12,100,'[\"{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\",\"{9ac8b41f-933e-4188-be8d-f4a5d81790d4}\",\"{77478c17-b0d9-4f97-8c40-fc3d63e238d0}\",\"{ecbf979e-0853-4801-bda3-a60b23015750}\"]','{c20cce93-c3d0-4ecb-8df7-7dedbaf34acf}',0,'2020-01-31 06:28:17','2020-01-31 06:28:17');
/*!40000 ALTER TABLE `Enviroments` ENABLE KEYS */;
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
INSERT INTO `GeneticMatches` VALUES ('{555babc2-3a1d-4025-b835-a8098945726c}','23',10862848,'C','F','rs3916649'),('{a6b6e490-4d92-4f0b-8352-3fd8a1e8d268}','40',10862847,'B','H','rs3916648'),('{b784b009-20e8-43c7-9251-5593e1183484}','45',10862849,'D','L','rs3916640'),('{f132a112-030b-423e-a304-69748cad26d5}','5',10862846,'A','T','rs3916645');
/*!40000 ALTER TABLE `GeneticMatches` ENABLE KEYS */;
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
INSERT INTO `Messages` VALUES ('{3b44a430-2d82-4623-af1f-2337f74e50c7}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','some message','2020-01-28 12:16:27'),('{e5c4c9fa-b3d8-4b5a-95ee-d96752e30cb2}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','message text','2020-01-31 09:21:24');
/*!40000 ALTER TABLE `Messages` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `Notifications`
--

DROP TABLE IF EXISTS `Notifications`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `Notifications` (
  `Id` varchar(38) NOT NULL,
  `Message` longtext DEFAULT NULL,
  `NoicationType` int(11) NOT NULL COMMENT 'Environment, Cohort, Pharma user etc',
  `Status` int(11) NOT NULL DEFAULT 0 COMMENT 'Created = 0, Read = 1, Cancelld = 2\n',
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
INSERT INTO `Notifications` VALUES ('{8a299213-b198-459b-b8d8-e7829f6e4677}','Environment request from Wendy Howard',0,0,'2020-01-31 12:00:00','2020-01-31 12:00:00');
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
INSERT INTO `PreviousTreatments` VALUES ('{94c14b9a-0cec-4c86-8a7d-53fb17ead9b8}','Mortin');
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
INSERT INTO `Prognosis` VALUES ('{e869be57-0400-4c55-9d6d-911e5af0a51f}','Tumor');
/*!40000 ALTER TABLE `Prognosis` ENABLE KEYS */;
UNLOCK TABLES;

--
-- Table structure for table `StageOfDeseases`
--

DROP TABLE IF EXISTS `StageOfDeseases`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `StageOfDeseases` (
  `Id` varchar(38) NOT NULL,
  `StageOfTumour` int(11) DEFAULT NULL,
  `NumberOfNodesAffected` int(11) DEFAULT NULL,
  `NumberOfMetastasis` int(11) DEFAULT NULL,
  PRIMARY KEY (`Id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `StageOfDeseases`
--

LOCK TABLES `StageOfDeseases` WRITE;
/*!40000 ALTER TABLE `StageOfDeseases` DISABLE KEYS */;
INSERT INTO `StageOfDeseases` VALUES ('{42511681-3320-4b70-8c8a-7b41a62edf07}',3,6,6);
/*!40000 ALTER TABLE `StageOfDeseases` ENABLE KEYS */;
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
  `Email` varchar(255) COLLATE utf8_unicode_ci NOT NULL,
  `FirstName` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `LastName` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `CompanyName` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Request` int(11) DEFAULT 0 COMMENT '0 - created\n1 - accepted\n2 - rejected',
  `Password` varchar(255) COLLATE utf8_unicode_ci DEFAULT NULL,
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
INSERT INTO `Users` VALUES ('{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','igor.ge@mail.ru_new1QQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQQ','Igor (TEST USER)','Grebenev','Quantumsoft',0,'','2020-01-30 10:15:46','2020-01-30 10:15:46'),('{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}','igor.grebenev@quantumsoft.ru','Igor','Grebenev','Quantumsoft Group',38,NULL,'2020-01-28 12:11:00','2020-01-28 12:16:27'),('{7d82c349-2ab7-4b07-8830-8e598caf2b1e}','test100@mail.ru','','','',0,'','2020-01-30 10:06:16','2020-01-30 10:06:16');
/*!40000 ALTER TABLE `Users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-01-31 16:47:29
