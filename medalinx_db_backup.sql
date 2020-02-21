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
  `DiseaseState` varchar(1024) DEFAULT NULL,
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
  `EnumItemId` varchar(38) DEFAULT NULL,
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
INSERT INTO `CohortEnumLink` VALUES ('{05ee0c77-c11b-475c-8711-9a3d8f95d55a}','{60ea1693-4f36-4d30-8b98-e4b5bf86620f}','{47f7bac5-60e6-4161-86d9-4ec5f561cafa}','{16caf670-ad0c-41d4-9ce6-b66bcb4d2ace}',0,0,'2020-02-19 08:47:27','2020-02-19 08:47:27'),('{23841597-363c-446b-9129-079476e6a81c}','{ff08dbcc-7c55-47e1-a5d3-5f6264b3dee1}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{1c308f58-c3e0-450d-91f4-9c5543129d42}',1,0,'2020-02-19 07:40:52','2020-02-19 07:40:52'),('{23a7e02b-3295-4c35-a8fd-3a40b0f6d0f4}','{ff08dbcc-7c55-47e1-a5d3-5f6264b3dee1}','{47f7bac5-60e6-4161-86d9-4ec5f561cafa}','{58c018fe-22ef-457c-82da-4c07f83d490c}',1,0,'2020-02-19 07:41:01','2020-02-19 07:41:01'),('{43913fa6-d5a4-411b-9491-e22650538f3f}','{00e6abe1-9a44-4f8b-88a4-589056d0d83f}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{1c308f58-c3e0-450d-91f4-9c5543129d42}',1,0,'2020-02-18 10:22:28','2020-02-18 10:22:28'),('{69208fe7-a7d7-4402-8239-fe23005e9990}','{ff08dbcc-7c55-47e1-a5d3-5f6264b3dee1}','{f1c60ef6-f4cc-45c6-9dc3-e53d9edc14c5}','{1b48b566-2323-4f84-9f13-311a189dbea7}',1,0,'2020-02-19 07:40:55','2020-02-19 07:40:55'),('{6a9f5318-6ff4-4dad-9ec9-8e919e7722e0}','{ff08dbcc-7c55-47e1-a5d3-5f6264b3dee1}','{152583bb-7105-462e-ad74-c9702696feae}','{0eb27144-8c1c-4ad6-a513-ce109fc735ec}',1,0,'2020-02-19 07:40:58','2020-02-19 07:40:58'),('{79f3a522-2026-4fad-bf19-d5c323948957}','{00e6abe1-9a44-4f8b-88a4-589056d0d83f}','{152583bb-7105-462e-ad74-c9702696feae}','{0eb27144-8c1c-4ad6-a513-ce109fc735ec}',1,0,'2020-02-18 10:22:32','2020-02-18 10:22:32'),('{850606cc-446c-4e6e-a9d4-0a2781a5a40f}','{00e6abe1-9a44-4f8b-88a4-589056d0d83f}','{47f7bac5-60e6-4161-86d9-4ec5f561cafa}','{dfd75b8b-b2e8-4c92-8eaf-b48a8a17f00a}',1,0,'2020-02-18 10:22:34','2020-02-18 10:22:34'),('{8d9a3e15-5415-48a2-a1f0-0b7dc17d80ed}','{00e6abe1-9a44-4f8b-88a4-589056d0d83f}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{2990b095-ad97-4144-a69f-b8007aa78ed3}',1,0,'2020-02-18 10:22:27','2020-02-18 10:22:27'),('{957d42c5-db04-404f-a547-3b4def0c8119}','{00e6abe1-9a44-4f8b-88a4-589056d0d83f}','{cc77ecca-8279-4c9d-b321-064ba492ba9e}','{089af994-0991-4e4a-bb0b-fac5c91450c0}',1,0,'2020-02-18 10:22:36','2020-02-18 10:22:36'),('{9c60f7a9-d70c-4d95-a34a-726d02bf0f10}','{60ea1693-4f36-4d30-8b98-e4b5bf86620f}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}',0,0,'2020-02-19 08:47:23','2020-02-19 08:47:23'),('{9e8e507a-dfd5-4d82-a2ff-b9d86e5d9aaf}','{ebfa7e2a-ab05-4d3e-abcb-9001702a6999}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}',1,0,'2020-02-19 07:55:30','2020-02-19 07:55:30'),('{a8315044-8894-4224-8606-914b4b384634}','{00e6abe1-9a44-4f8b-88a4-589056d0d83f}','{5d65643e-4060-48e3-a094-347133b0ed81}','{3eb9d916-1a66-495d-9ba9-3f28f4510daf}',1,0,'2020-02-18 10:22:31','2020-02-18 10:22:31'),('{ab8fca6b-eba9-4079-973f-280768f58474}','{ff08dbcc-7c55-47e1-a5d3-5f6264b3dee1}','{5d65643e-4060-48e3-a094-347133b0ed81}','{3eb9d916-1a66-495d-9ba9-3f28f4510daf}',1,0,'2020-02-19 07:40:57','2020-02-19 07:40:57'),('{b420dc1c-79da-47e8-b0ac-ad04949770da}','{60ea1693-4f36-4d30-8b98-e4b5bf86620f}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{2990b095-ad97-4144-a69f-b8007aa78ed3}',0,0,'2020-02-19 08:47:21','2020-02-19 08:47:21'),('{b8bc4113-3e8d-4428-acbb-9d4658dfce52}','{ff08dbcc-7c55-47e1-a5d3-5f6264b3dee1}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{2990b095-ad97-4144-a69f-b8007aa78ed3}',0,0,'2020-02-19 07:40:49','2020-02-19 07:40:49'),('{bddf2814-c102-4559-9143-62fd37410ce7}','{60ea1693-4f36-4d30-8b98-e4b5bf86620f}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{74e05cd7-8b87-4b34-86a0-73cac65db1a5}',1,0,'2020-02-19 08:47:24','2020-02-19 08:47:24'),('{c39757f9-8171-442d-a1fb-6008460155b3}','{ff08dbcc-7c55-47e1-a5d3-5f6264b3dee1}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{74e05cd7-8b87-4b34-86a0-73cac65db1a5}',1,0,'2020-02-19 07:40:54','2020-02-19 07:40:54'),('{cde89ae7-94d4-4ad4-ba10-ef6aa4eec878}','{00e6abe1-9a44-4f8b-88a4-589056d0d83f}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{74e05cd7-8b87-4b34-86a0-73cac65db1a5}',1,0,'2020-02-18 10:22:29','2020-02-18 10:22:29'),('{d6fd343d-6b36-4267-b9a7-b58fb4bb7d3b}','{00e6abe1-9a44-4f8b-88a4-589056d0d83f}','{f1c60ef6-f4cc-45c6-9dc3-e53d9edc14c5}','{1b48b566-2323-4f84-9f13-311a189dbea7}',1,0,'2020-02-18 10:22:30','2020-02-18 10:22:30'),('{feae7805-82b9-468e-b8b1-0f842a87f2ae}','{ff08dbcc-7c55-47e1-a5d3-5f6264b3dee1}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}',1,0,'2020-02-19 07:40:51','2020-02-19 07:40:51');
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
  `UserId` varchar(38) NOT NULL DEFAULT '{00000000-0000-0000-0000-000000000000}',
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
INSERT INTO `Cohorts` VALUES ('{00e6abe1-9a44-4f8b-88a4-589056d0d83f}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}',122,'static',20,20,0,20,'2020-02-18 10:22:26','2020-02-18 10:22:26'),('{60ea1693-4f36-4d30-8b98-e4b5bf86620f}','{bde09723-429a-4d20-a0e1-ab1672936243}',1,'dynamic',20,20,0,0,'2020-02-19 08:37:25','2020-02-19 08:47:16'),('{ebfa7e2a-ab05-4d3e-abcb-9001702a6999}','{bde09723-429a-4d20-a0e1-ab1672936243}',1,'dynamic',0,30,0,0,'2020-02-19 07:55:29','2020-02-19 07:55:29'),('{ff08dbcc-7c55-47e1-a5d3-5f6264b3dee1}','{bde09723-429a-4d20-a0e1-ab1672936243}',2,'dynamic',0,30,0,0,'2020-02-19 07:28:38','2020-02-19 07:40:41');
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
INSERT INTO `Demographics` VALUES ('{16caf670-ad0c-41d4-9ce6-b66bcb4d2ace}',1,2,'1'),('{218f2c71-3afd-4be8-91f5-1e7868a90448}',1,2,'0'),('{58c018fe-22ef-457c-82da-4c07f83d490c}',1,2,'0'),('{af5782f3-4678-4b3a-855e-de5225830409}',1,2,'1'),('{dfd75b8b-b2e8-4c92-8eaf-b48a8a17f00a}',1,2,'0');
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
  `UserId` varchar(38) NOT NULL,
  `NumberOfUsers` int(11) DEFAULT 0,
  `DataStorage` float DEFAULT 0 COMMENT 'Data strorage GB',
  `AnalyticalApplication` longtext NOT NULL COMMENT 'Array of analytical applications',
  `TypeOfConnectivity` varchar(38) DEFAULT '{00000000-0000-0000-0000-000000000000}',
  `Request` int(11) DEFAULT NULL,
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
INSERT INTO `Environments` VALUES ('{2ae0f025-2b87-41cb-b47e-a47abbaaa69a}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}',1,1,'[\"{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\",\"{6b9a507e-3340-4d64-8fd9-908a69c00f6d}\"]','{2f3ff4f0-b363-40ba-990d-7b80f0df574f}',20,0,'2020-02-18 10:17:32','2020-02-18 10:17:32'),('{95e16f6d-422c-4816-b130-8c185fa08728}','{bde09723-429a-4d20-a0e1-ab1672936243}',1,2,'[\"{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\",\"{9ac8b41f-933e-4188-be8d-f4a5d81790d4}\",\"{a3726509-f0f1-47a1-8d1c-01d6dbd3972b}\",\"{d03e9edd-0b89-4423-bb0c-9a1882fe312b}\"]','{c20cce93-c3d0-4ecb-8df7-7dedbaf34acf}',20,0,'2020-02-19 06:47:33','2020-02-19 06:47:33');
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
INSERT INTO `HistoryItems` VALUES ('{15ab7608-46b3-424e-b14b-ca6ba471d000}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','{00e6abe1-9a44-4f8b-88a4-589056d0d83f}','MedalynxAPI.Controllers.CohortsController','Cohort approved by user. id: {00e6abe1-9a44-4f8b-88a4-589056d0d83f}','2020-02-19 12:00:40'),('{1b984d32-6f44-41cb-b172-53e5d7d926f9}','{bde09723-429a-4d20-a0e1-ab1672936243}','{ff08dbcc-7c55-47e1-a5d3-5f6264b3dee1}','MedalynxAPI.Controllers.CohortsController','Update cohort called with data:{\"Id\":\"{ff08dbcc-7c55-47e1-a5d3-5f6264b3dee1}\",\"UserId\":\"{bde09723-429a-4d20-a0e1-ab1672936243}\",\"NumberOfSubjectsRequired\":2,\"CohortType\":\"dynamic\",\"RequestAdmin\":0,\"RequestUser\":0,\"cohortEnumLinks\":[{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{2990b095-ad97-4144-a69f-b8007aa78ed3}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}\",\"EnumItemId\":\"{1c308f58-c3e0-450d-91f4-9c5543129d42}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}\",\"EnumItemId\":\"{74e05cd7-8b87-4b34-86a0-73cac65db1a5}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{f1c60ef6-f4cc-45c6-9dc3-e53d9edc14c5}\",\"EnumItemId\":\"{1b48b566-2323-4f84-9f13-311a189dbea7}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{5d65643e-4060-48e3-a094-347133b0ed81}\",\"EnumItemId\":\"{3eb9d916-1a66-495d-9ba9-3f28f4510daf}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{152583bb-7105-462e-ad74-c9702696feae}\",\"EnumItemId\":\"{0eb27144-8c1c-4ad6-a513-ce109fc735ec}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{47f7bac5-60e6-4161-86d9-4ec5f561cafa}\",\"EnumItemId\":\"{58c018fe-22ef-457c-82da-4c07f83d490c}\",\"Include\":1,\"Percentage\":0,\"enumItem\":{\"Id\":\"{218f2c71-3afd-4be8-91f5-1e7868a90448}\",\"AgeFrom\":1,\"AgeTo\":2,\"Alt\":null,\"Chromosome\":null,\"dbSNP\":null,\"DiseaseState\":null,\"Gender\":\"0\",\"Keyword\":null,\"Nationality\":null,\"NumberOfNodesAffected\":0,\"NumberOfMetastasis\":0,\"Position\":0,\"Ref\":null,\"StageOfTumour\":0}}]}','2020-02-19 07:41:02'),('{2743e028-5d57-4a4a-8864-5d361b7a5b29}','{bde09723-429a-4d20-a0e1-ab1672936243}','{60ea1693-4f36-4d30-8b98-e4b5bf86620f}','MedalynxAPI.Controllers.CohortsController','Update cohort called with data:{\"Id\":\"{60ea1693-4f36-4d30-8b98-e4b5bf86620f}\",\"UserId\":\"{bde09723-429a-4d20-a0e1-ab1672936243}\",\"NumberOfSubjectsRequired\":1,\"CohortType\":\"dynamic\",\"RequestAdmin\":0,\"RequestUser\":0,\"cohortEnumLinks\":[{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{2990b095-ad97-4144-a69f-b8007aa78ed3}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}\",\"EnumItemId\":\"{74e05cd7-8b87-4b34-86a0-73cac65db1a5}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{47f7bac5-60e6-4161-86d9-4ec5f561cafa}\",\"EnumItemId\":\"{16caf670-ad0c-41d4-9ce6-b66bcb4d2ace}\",\"Include\":0,\"Percentage\":0,\"enumItem\":{\"Id\":\"{af5782f3-4678-4b3a-855e-de5225830409}\",\"AgeFrom\":1,\"AgeTo\":2,\"Alt\":null,\"Chromosome\":null,\"dbSNP\":null,\"DiseaseState\":null,\"Gender\":\"1\",\"Keyword\":null,\"Nationality\":null,\"NumberOfNodesAffected\":0,\"NumberOfMetastasis\":0,\"Position\":0,\"Ref\":null,\"StageOfTumour\":0}}]}','2020-02-19 08:47:28'),('{40ae09c8-0d3e-4b35-b577-654d7d48eff9}','{bde09723-429a-4d20-a0e1-ab1672936243}','{60ea1693-4f36-4d30-8b98-e4b5bf86620f}','MedalynxAPI.Controllers.CohortsController','Create cohort called with data:{\"Id\":\"{60ea1693-4f36-4d30-8b98-e4b5bf86620f}\",\"UserId\":\"{bde09723-429a-4d20-a0e1-ab1672936243}\",\"NumberOfSubjectsRequired\":1,\"CohortType\":\"dynamic\",\"RequestAdmin\":0,\"RequestUser\":0,\"cohortEnumLinks\":[{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{2990b095-ad97-4144-a69f-b8007aa78ed3}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null}]}','2020-02-19 08:37:27'),('{413a0fba-2977-410e-a16c-920e54d89a7f}','{bde09723-429a-4d20-a0e1-ab1672936243}','{ff08dbcc-7c55-47e1-a5d3-5f6264b3dee1}','MedalynxAPI.Controllers.CohortsController','Cohort rejected by user. id: {ff08dbcc-7c55-47e1-a5d3-5f6264b3dee1}','2020-02-19 07:41:24'),('{4731f6e3-3bdc-40a1-88e0-b91a57a07587}','{57a98e8e-f5ab-4032-b647-b793b60468ff}','{95e16f6d-422c-4816-b130-8c185fa08728}','MedalynxAPI.Controllers.EnvironmentsController','Update environment called with data:{\"Id\":\"{95e16f6d-422c-4816-b130-8c185fa08728}\",\"UserId\":\"{bde09723-429a-4d20-a0e1-ab1672936243}\",\"NumberOfUsers\":1,\"DataStorage\":2,\"AnalyticalApplication\":\"[\\u0022{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\\u0022,\\u0022{9ac8b41f-933e-4188-be8d-f4a5d81790d4}\\u0022,\\u0022{a3726509-f0f1-47a1-8d1c-01d6dbd3972b}\\u0022,\\u0022{d03e9edd-0b89-4423-bb0c-9a1882fe312b}\\u0022]\",\"TypeOfConnectivity\":\"{c20cce93-c3d0-4ecb-8df7-7dedbaf34acf}\",\"Request\":20,\"Status\":0,\"CreationDate\":\"0001-01-01T00:00:00\",\"LastUpdate\":\"0001-01-01T00:00:00\"}','2020-02-19 06:48:50'),('{676a356f-6a12-4c87-9081-265c4f8f2156}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','{00e6abe1-9a44-4f8b-88a4-589056d0d83f}','MedalynxAPI.Controllers.CohortsController','Cohort RequestType updated. id: {00e6abe1-9a44-4f8b-88a4-589056d0d83f}','2020-02-19 07:03:34'),('{8bb9c0b4-b0bf-43f5-b8ab-247fc5b190d5}','{bde09723-429a-4d20-a0e1-ab1672936243}','{60ea1693-4f36-4d30-8b98-e4b5bf86620f}','MedalynxAPI.Controllers.CohortsController','Cohort approved by user. id: {60ea1693-4f36-4d30-8b98-e4b5bf86620f}','2020-02-19 08:50:00'),('{a55c02a7-460c-4372-b1fc-eacff3aa8151}','{57a98e8e-f5ab-4032-b647-b793b60468ff}','{60ea1693-4f36-4d30-8b98-e4b5bf86620f}','MedalynxAPI.Controllers.CohortsController','Cohort approved by admin. id: {60ea1693-4f36-4d30-8b98-e4b5bf86620f}','2020-02-19 08:49:24'),('{a65c01c7-d7f3-4e63-97f5-6216b17e8391}','{57a98e8e-f5ab-4032-b647-b793b60468ff}','{60ea1693-4f36-4d30-8b98-e4b5bf86620f}','MedalynxAPI.Controllers.CohortsController','Cohort approved by admin. id: {60ea1693-4f36-4d30-8b98-e4b5bf86620f}','2020-02-19 08:41:48'),('{b5ff58e1-c55a-47bd-bea7-752d1b833d5c}','{57a98e8e-f5ab-4032-b647-b793b60468ff}','{60ea1693-4f36-4d30-8b98-e4b5bf86620f}','MedalynxAPI.Controllers.CohortsController','Update cohort called with data:{\"Id\":\"{60ea1693-4f36-4d30-8b98-e4b5bf86620f}\",\"UserId\":\"{bde09723-429a-4d20-a0e1-ab1672936243}\",\"NumberOfSubjectsRequired\":1,\"CohortType\":\"dynamic\",\"RequestAdmin\":20,\"RequestUser\":0,\"cohortEnumLinks\":[{\"Id\":\"{9f3dd7de-90bb-46f0-9607-feef77c028fe}\",\"CohortId\":\"{60ea1693-4f36-4d30-8b98-e4b5bf86620f}\",\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{2990b095-ad97-4144-a69f-b8007aa78ed3}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":\"{d9f78920-36f7-482b-9594-ea0f58251d1b}\",\"CohortId\":\"{60ea1693-4f36-4d30-8b98-e4b5bf86620f}\",\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null}]}','2020-02-19 08:38:39'),('{be4aa407-986d-4aa7-acc1-c75e5a7adea0}','{57a98e8e-f5ab-4032-b647-b793b60468ff}','{60ea1693-4f36-4d30-8b98-e4b5bf86620f}','MedalynxAPI.Controllers.CohortsController','Update cohort called with data:{\"Id\":\"{60ea1693-4f36-4d30-8b98-e4b5bf86620f}\",\"UserId\":\"{bde09723-429a-4d20-a0e1-ab1672936243}\",\"NumberOfSubjectsRequired\":1,\"CohortType\":\"dynamic\",\"RequestAdmin\":0,\"RequestUser\":0,\"cohortEnumLinks\":[{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{2990b095-ad97-4144-a69f-b8007aa78ed3}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null}]}','2020-02-19 08:38:26'),('{c55f62da-f1cc-4446-8764-ca9b00c602c8}','{bde09723-429a-4d20-a0e1-ab1672936243}','{60ea1693-4f36-4d30-8b98-e4b5bf86620f}','MedalynxAPI.Controllers.CohortsController','Update cohort called with data:{\"Id\":\"{60ea1693-4f36-4d30-8b98-e4b5bf86620f}\",\"UserId\":\"{bde09723-429a-4d20-a0e1-ab1672936243}\",\"NumberOfSubjectsRequired\":1,\"CohortType\":\"dynamic\",\"RequestAdmin\":0,\"RequestUser\":0,\"cohortEnumLinks\":[{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{2990b095-ad97-4144-a69f-b8007aa78ed3}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}\",\"EnumItemId\":\"{74e05cd7-8b87-4b34-86a0-73cac65db1a5}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{47f7bac5-60e6-4161-86d9-4ec5f561cafa}\",\"EnumItemId\":\"{af5782f3-4678-4b3a-855e-de5225830409}\",\"Include\":0,\"Percentage\":0,\"enumItem\":{\"Id\":null,\"AgeFrom\":1,\"AgeTo\":2,\"Alt\":null,\"Chromosome\":null,\"dbSNP\":null,\"DiseaseState\":null,\"Gender\":\"1\",\"Keyword\":null,\"Nationality\":null,\"NumberOfNodesAffected\":0,\"NumberOfMetastasis\":0,\"Position\":0,\"Ref\":null,\"StageOfTumour\":0}}]}','2020-02-19 08:40:57'),('{da93700a-bedd-4515-ab1a-c5aa4fa3c3a8}','{bde09723-429a-4d20-a0e1-ab1672936243}','{ebfa7e2a-ab05-4d3e-abcb-9001702a6999}','MedalynxAPI.Controllers.CohortsController','Cohort rejected by user. id: {ebfa7e2a-ab05-4d3e-abcb-9001702a6999}','2020-02-19 08:27:24'),('{dc4e64a3-8f61-483e-88d5-d3a533b46cff}','{bde09723-429a-4d20-a0e1-ab1672936243}','{95e16f6d-422c-4816-b130-8c185fa08728}','MedalynxAPI.Controllers.EnvironmentsController','Create environment called with data:{\"Id\":\"{95e16f6d-422c-4816-b130-8c185fa08728}\",\"UserId\":\"{bde09723-429a-4d20-a0e1-ab1672936243}\",\"NumberOfUsers\":1,\"DataStorage\":2,\"AnalyticalApplication\":\"[\\u0022{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\\u0022,\\u0022{9ac8b41f-933e-4188-be8d-f4a5d81790d4}\\u0022,\\u0022{a3726509-f0f1-47a1-8d1c-01d6dbd3972b}\\u0022]\",\"TypeOfConnectivity\":\"{2f3ff4f0-b363-40ba-990d-7b80f0df574f}\",\"Request\":0,\"Status\":0,\"CreationDate\":\"2020-02-19T06:47:33.631367Z\",\"LastUpdate\":\"2020-02-19T06:47:33.631367Z\"}','2020-02-19 06:47:35'),('{f3ceaa79-bbff-43da-ba83-9902ab03315e}','{57a98e8e-f5ab-4032-b647-b793b60468ff}','{00e6abe1-9a44-4f8b-88a4-589056d0d83f}','MedalynxAPI.Controllers.CohortsController','Cohort approved by admin. id: {00e6abe1-9a44-4f8b-88a4-589056d0d83f}','2020-02-19 11:22:26'),('{fdcc3bfc-ca4b-4dbb-a37d-36de501d6b0b}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','{ebfa7e2a-ab05-4d3e-abcb-9001702a6999}','MedalynxAPI.Controllers.CohortsController','Create cohort called with data:{\"Id\":\"{ebfa7e2a-ab05-4d3e-abcb-9001702a6999}\",\"UserId\":\"{bde09723-429a-4d20-a0e1-ab1672936243}\",\"NumberOfSubjectsRequired\":1,\"CohortType\":\"dynamic\",\"RequestAdmin\":0,\"RequestUser\":0,\"cohortEnumLinks\":[{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null}]}','2020-02-19 07:55:31');
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
  `Message` longtext DEFAULT NULL,
  `NotificationType` int(11) NOT NULL COMMENT 'Environment, Cohort, Pharma user etc',
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
INSERT INTO `Notifications` VALUES ('{15a8bb31-b884-43cc-86a4-862eacc8f420}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','Cohort created',0,0,'2020-02-19 07:55:32','2020-02-19 07:55:32'),('{1739f32d-3659-498a-bbfd-209d375f7fbf}','{bde09723-429a-4d20-a0e1-ab1672936243}','Cohort created',0,0,'2020-02-19 08:37:29','2020-02-19 08:37:29'),('{3b129e7c-a37c-439d-acef-b67b038ac97c}','{bde09723-429a-4d20-a0e1-ab1672936243}','Environment created',1,0,'2020-02-19 06:47:34','2020-02-19 06:47:34'),('{66edb680-3dab-47c3-bd8d-4362591e70e7}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','Environment created',1,0,'2020-02-18 10:17:34','2020-02-18 10:17:34'),('{db8242c4-fe87-450d-9a5f-eb56d81e4990}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','Cohort created',0,0,'2020-02-18 10:22:38','2020-02-18 10:22:38');
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
INSERT INTO `Sessions` VALUES ('{37f44bab-ee70-4704-a74b-8050031aeb48}','{57a98e8e-f5ab-4032-b647-b793b60468ff}','2020-02-21 05:09:13','2020-02-21 05:09:13'),('{98c41a14-2e6a-4e43-8652-753bb27e9adc}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','2020-02-19 07:35:16','2020-02-19 07:35:16');
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
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-02-21 12:14:50
