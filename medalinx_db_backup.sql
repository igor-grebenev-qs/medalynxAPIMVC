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
INSERT INTO `CohortEnumLink` VALUES ('{0224774d-5701-47d3-9f2c-31ecc61e19b4}','{e25d8995-3215-41a2-935c-66c267fc1781}','{152583bb-7105-462e-ad74-c9702696feae}','{94c14b9a-0cec-4c86-8a7d-53fb17ead9b8}',1,0,'2020-02-11 07:19:32','2020-02-11 07:19:32'),('{0b876e1a-b12c-4695-acf2-b31a5c23045a}','{e25d8995-3215-41a2-935c-66c267fc1781}','{47f7bac5-60e6-4161-86d9-4ec5f561cafa}','{7dcd0022-ab9f-4b5b-ad77-3eb0f923240a}',0,0,'2020-02-11 07:19:34','2020-02-11 07:19:34'),('{0c50ac66-542e-45b3-9331-efd911b4cd84}','{e25d8995-3215-41a2-935c-66c267fc1781}','{5d65643e-4060-48e3-a094-347133b0ed81}','{e869be57-0400-4c55-9d6d-911e5af0a51f}',1,0,'2020-02-11 07:19:30','2020-02-11 07:19:30'),('{0ec24346-225b-4dd1-88c3-aeaa4512c74c}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{3399fdb9-f33c-4532-8fc4-cd370fde592e}',1,0,'2020-02-10 06:16:28','2020-02-10 06:16:28'),('{0ed2619e-c938-487f-9503-47380074f4d0}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{cc77ecca-8279-4c9d-b321-064ba492ba9e}',NULL,0,0,'2020-02-10 06:16:40','2020-02-10 06:16:40'),('{16e8f2b8-b84d-4682-9206-3f9d5a73a6ea}','{e25d8995-3215-41a2-935c-66c267fc1781}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}',1,0,'2020-02-11 07:19:20','2020-02-11 07:19:20'),('{19c75e98-3b4b-4da5-9ece-9895228f2df8}','{e25d8995-3215-41a2-935c-66c267fc1781}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{7b1b6585-e9dd-4d17-9ef0-af179246e2b3}',0,0,'2020-02-11 07:19:26','2020-02-11 07:19:26'),('{1a640acc-5713-48df-b181-69f89adbb1ad}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{5d65643e-4060-48e3-a094-347133b0ed81}','{e869be57-0400-4c55-9d6d-911e5af0a51f}',1,0,'2020-02-10 06:16:33','2020-02-10 06:16:33'),('{1bd300d1-269f-4843-9a4d-3b760edd602f}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{7b1b6585-e9dd-4d17-9ef0-af179246e2b3}',1,0,'2020-02-10 06:16:29','2020-02-10 06:16:29'),('{2e2ffc0a-de6e-4c1f-861c-467c8171b4fd}','{e25d8995-3215-41a2-935c-66c267fc1781}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{92f64a21-6170-4019-8cc8-917ab7e8b4dd}',0,0,'2020-02-11 07:19:27','2020-02-11 07:19:27'),('{44cc55b6-2b34-4376-b4fb-b3e98ad6e3ee}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{cc77ecca-8279-4c9d-b321-064ba492ba9e}',NULL,1,0,'2020-02-10 06:16:39','2020-02-10 06:16:39'),('{500b97c0-9b1e-490f-be94-32226d114629}','{e25d8995-3215-41a2-935c-66c267fc1781}','{47f7bac5-60e6-4161-86d9-4ec5f561cafa}','{9ac99754-711d-480a-84fc-e9f69a574c31}',1,0,'2020-02-11 07:19:37','2020-02-11 07:19:37'),('{5faf4790-84a6-4862-9921-5ffe3e4a6f14}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{f132a112-030b-423e-a304-69748cad26d5}',0,0,'2020-02-10 06:16:27','2020-02-10 06:16:27'),('{6c705bdc-affb-4b52-a04d-a634e379930c}','{248b5596-9b28-43b4-b433-c45fff62921c}','{cc77ecca-8279-4c9d-b321-064ba492ba9e}','{f142b6e2-e5eb-42ba-bf2e-373cca7a19bc}',1,10,'2020-02-09 06:40:30','2020-02-09 06:40:30'),('{75241a68-49bc-4d6b-8a0b-fadfe1049570}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{152583bb-7105-462e-ad74-c9702696feae}','{94c14b9a-0cec-4c86-8a7d-53fb17ead9b8}',0,0,'2020-02-10 06:16:34','2020-02-10 06:16:34'),('{7bd6e696-80ee-44ed-9689-d81e5234565a}','{e25d8995-3215-41a2-935c-66c267fc1781}','{cc77ecca-8279-4c9d-b321-064ba492ba9e}','{4131b970-6d1f-4343-b22e-5fa13867a5ca}',0,0,'2020-02-11 07:19:42','2020-02-11 07:19:42'),('{7c76c634-52ca-4747-8781-77590c6ed59b}','{e25d8995-3215-41a2-935c-66c267fc1781}','{f1c60ef6-f4cc-45c6-9dc3-e53d9edc14c5}','{1b48b566-2323-4f84-9f13-311a189dbea7}',0,0,'2020-02-11 07:19:29','2020-02-11 07:19:29'),('{92584954-9bc0-4e0d-89b0-254c0b8fa578}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}',0,0,'2020-02-10 06:16:21','2020-02-10 06:16:21'),('{990c935d-ca67-4412-832a-6f1be6c480d4}','{e25d8995-3215-41a2-935c-66c267fc1781}','{cc77ecca-8279-4c9d-b321-064ba492ba9e}','{20a81a7a-7b33-463d-851e-e51d88264578}',1,0,'2020-02-11 07:19:44','2020-02-11 07:19:44'),('{9b391915-2429-4e21-a4f3-052675d560f8}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{f14840b5-46c2-46e8-a92c-f9b2dbc5dbd7}',1,0,'2020-02-10 06:16:23','2020-02-10 06:16:23'),('{a935d4d8-d6a6-4c6f-9a6f-edf804feaf45}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{4f57817f-3113-4f2f-9617-ca881061df2b}',1,0,'2020-02-10 06:16:20','2020-02-10 06:16:20'),('{ac997b6d-e110-4477-b3d4-9ba86656b8f1}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{555babc2-3a1d-4025-b835-a8098945726c}',0,0,'2020-02-10 06:16:24','2020-02-10 06:16:24'),('{b00a7837-a5de-4a09-a1f6-8546cd796cef}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{cc77ecca-8279-4c9d-b321-064ba492ba9e}',NULL,1,0,'2020-02-10 06:16:38','2020-02-10 06:16:38'),('{b53e545b-f1fd-441d-90b6-03eb6611a070}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{47f7bac5-60e6-4161-86d9-4ec5f561cafa}',NULL,1,0,'2020-02-10 06:16:36','2020-02-10 06:16:36'),('{b626d612-45bb-4f13-944a-58998c8b0c1a}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{cace0279-ad76-4529-bc2e-58078c665bdb}',0,0,'2020-02-10 06:16:22','2020-02-10 06:16:22'),('{bf6fc1f9-ac41-4067-b053-4396f78ab549}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{a6b6e490-4d92-4f0b-8352-3fd8a1e8d268}',1,0,'2020-02-10 06:16:25','2020-02-10 06:16:25'),('{c05370b9-f0c5-41f9-aafc-9caa641569db}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{f1c60ef6-f4cc-45c6-9dc3-e53d9edc14c5}','{1b48b566-2323-4f84-9f13-311a189dbea7}',1,0,'2020-02-10 06:16:32','2020-02-10 06:16:32'),('{d2176b5e-76da-4afa-b330-22575f4ba047}','{e25d8995-3215-41a2-935c-66c267fc1781}','{47f7bac5-60e6-4161-86d9-4ec5f561cafa}','{491d54dd-c73f-45ca-a91d-2af88fdddfe8}',1,0,'2020-02-11 07:19:39','2020-02-11 07:19:39'),('{d4fdcc39-952f-4529-8959-7346284bcbb3}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{92f64a21-6170-4019-8cc8-917ab7e8b4dd}',0,0,'2020-02-10 06:16:31','2020-02-10 06:16:31'),('{d515b2d8-1904-4491-b074-16187955d685}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{b784b009-20e8-43c7-9251-5593e1183484}',1,0,'2020-02-10 06:16:26','2020-02-10 06:16:26'),('{e0f5a915-e20a-445c-808b-861db66f95c1}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{7f93db44-b29a-4039-a836-e713044d444c}',0,0,'2020-02-10 06:16:30','2020-02-10 06:16:30'),('{e53201b5-bd7b-4a7c-bcd0-8be3fc7e8f8e}','{dfaf36d7-5b30-4906-aa36-d3c424845d90}','{47f7bac5-60e6-4161-86d9-4ec5f561cafa}',NULL,1,0,'2020-02-10 06:16:37','2020-02-10 06:16:37'),('{f0312269-1134-4818-be98-0a03ac7c337e}','{e25d8995-3215-41a2-935c-66c267fc1781}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{7f93db44-b29a-4039-a836-e713044d444c}',0,0,'2020-02-11 07:19:24','2020-02-11 07:19:24'),('{f400965c-0cdc-4426-8e51-3a3e1c8ab0bb}','{e25d8995-3215-41a2-935c-66c267fc1781}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{3399fdb9-f33c-4532-8fc4-cd370fde592e}',0,0,'2020-02-11 07:19:23','2020-02-11 07:19:23'),('{f6da00e8-c98e-47f4-bb02-28769a92656b}','{e25d8995-3215-41a2-935c-66c267fc1781}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{4f57817f-3113-4f2f-9617-ca881061df2b}',0,0,'2020-02-11 07:19:21','2020-02-11 07:19:21');
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
INSERT INTO `Cohorts` VALUES ('{24514168-2a0a-4ac7-883a-6a80dc83a48f}','{5df24651-ebbf-4863-b1d7-416d70f8e94b}',6,'dynamic',0,'2020-02-10 05:41:32','2020-02-10 05:41:32'),('{248b5596-9b28-43b4-b433-c45fff62921c}','{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}',1,'unknown',2,'2020-02-06 12:08:32','2020-02-09 06:40:18'),('{d2966ac2-6475-4b0a-9809-40decc99e2e6}','{e928d946-5350-4f0d-9b94-6262c39d1058}',80,'unknown',0,'2020-02-07 11:06:51','2020-02-07 11:06:51'),('{e25d8995-3215-41a2-935c-66c267fc1781}','{b3643e06-bd3a-4429-aacb-89a52f8f7950}',10,'dynamic',0,'2020-02-11 05:14:44','2020-02-11 07:19:09'),('{e7d07c9f-86e1-4114-89eb-9ce62dd8134d}','{de3fd19d-4583-46d1-8c97-30ef6ec5f604}',6,'dynamic',0,'2020-02-10 05:48:25','2020-02-10 05:48:25');
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
INSERT INTO `Demographics` VALUES ('{0330b1a8-2be4-477d-9714-d0b4d5dc294d}',1,100,'2'),('{04421a46-3308-47b4-aa60-89f5820806d8}',3,15,'2'),('{04957656-af09-4d08-b23f-6b0ee0f98c29}',3,15,'2'),('{051b38f0-d7e7-4f8e-a92a-5c88fbe09a1a}',1,2,'0'),('{070b7461-31d6-47fa-bae0-5d6129ac10b5}',3,15,'2'),('{0a686258-313e-4465-b325-199d28f24510}',1,2,'0'),('{0c49b079-cb94-4ea2-a7ac-627cd75d2b90}',1,2,'0'),('{14cf985e-9ce1-4eaf-8831-b8bf1e9f1495}',0,0,'mail'),('{1999378b-c4fc-4821-8087-4b7c6b8cdff6}',1,2,'0'),('{25f9f7fa-a0f4-4bbf-9cc8-6b9fba732566}',1,2,'0'),('{274e8ce4-ea8b-4626-b262-96450f119b3c}',1,2,'0'),('{283d7e04-cdf7-4bc8-adc2-ed651e4a57f1}',1,100,'2'),('{2be12b93-0368-4e8c-9084-340e4d5ae4d8}',3,15,'2'),('{2f7985d1-382b-4dbd-9038-2a1f31d01ae8}',1,133,'2'),('{34cf517c-c6c7-4a59-9f9e-76df3cf9e89e}',1,2,'0'),('{393d75ed-be9e-49c3-9069-8104d29d1a9a}',3,15,'2'),('{3e33c9a7-b185-4b8a-9e81-20c4eb4d283c}',3,15,'2'),('{4360601c-bace-416f-a16b-80fad506b30f}',1,2,'0'),('{43ad4595-3796-4ab2-bb32-a6a964852e88}',1,2,'0'),('{491d54dd-c73f-45ca-a91d-2af88fdddfe8}',1,2,'0'),('{4f9a13a5-a800-43e8-9941-9016adf0a47e}',1,2,'0'),('{600a4637-de9d-42dd-a4c8-8437392495ab}',0,0,'mail'),('{6bfab8bc-e025-4fd5-986b-1b84b6ab219f}',3,15,'2'),('{769af33a-41c6-49bb-8a46-efc09cb37d79}',1,2,'0'),('{7dcd0022-ab9f-4b5b-ad77-3eb0f923240a}',1,100,'2'),('{7de3d003-20c5-43be-8bbc-ba395873ba09}',1,2,'0'),('{832215dd-6529-4b9c-9997-e72d624026bb}',1,2,'0'),('{83d89ccd-4a99-404c-8375-a21219942165}',1,100,'2'),('{8a93818a-9640-4b51-af96-d4968e641cea}',1,2,'0'),('{9369361f-0cbd-4760-9992-2266a232f765}',1,100,'2'),('{95ce497a-485e-40e1-afea-9c2cb38b8be8}',1,100,'2'),('{9ac99754-711d-480a-84fc-e9f69a574c31}',1,2,'0'),('{9f62dc6b-3f8a-43dc-a7c4-7502a5ac0312}',0,0,'0'),('{a01dc816-3c72-4fed-a917-6e51cdc6f809}',1,2,'0'),('{acb0eeeb-e141-4e34-8177-274fd392a39d}',NULL,NULL,'Female'),('{ad4e8362-b623-405b-bc58-52e622b82262}',2,1,'2'),('{af96a2f5-b107-40de-b78a-d2852de7780e}',1,2,'0'),('{b779aaea-ad09-4054-9a3a-59ed57cd0f06}',1,2,'0'),('{b7a33dfe-1b83-40ef-9c79-9db1c607ea5f}',1,3,'2'),('{b94317b0-27a5-449c-bb8f-0d2158aea491}',1,3,'0'),('{bc7c6ef3-8d3d-484b-8ae4-14039ea9cb0b}',3,15,'2'),('{bca3b30e-90cc-4c86-89c2-c917d05fa194}',0,0,'2'),('{c101b94f-bd29-4e00-a37a-b413dfeb9a6a}',3,15,'2'),('{c2474a7f-16db-4bc9-b7f4-915f4baadd48}',NULL,NULL,'Male'),('{c2993a63-d315-49c5-bda7-93d21f6ab244}',1,2,'0'),('{cce1b52a-354a-4b38-b0bd-78dc2d9fd123}',1,2,'0'),('{d6298874-83c1-4e9e-82a6-21083313029b}',1,2,'0'),('{dbc7e664-4b3a-49ff-9baf-5609e0214cc1}',1,2,'0'),('{dcbcbed1-fde9-4c53-b563-1eb8d46e7963}',3,15,'2'),('{dfaf2e4d-f66f-44cb-a80f-8025f20a3325}',1,2,'0'),('{ed7fd872-88b9-4d5f-bdb3-bacc90d34a66}',1,100,'2'),('{f848d35c-a133-417c-9ce9-dd85b317eb1d}',3,15,'2');
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
INSERT INTO `Enviroments` VALUES ('{0ed48902-e09c-4af9-bd8f-e9ff1d0a8c52}','{b3643e06-bd3a-4429-aacb-89a52f8f7950}',1,1,'[\"{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\"]','{2f3ff4f0-b363-40ba-990d-7b80f0df574f}',1,'2020-02-10 06:03:17','2020-02-10 06:03:17'),('{1571c3af-311d-4537-9c6d-d4a6848880d5}','{e928d946-5350-4f0d-9b94-6262c39d1058}',50,90,'[\"{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\"]','{c20cce93-c3d0-4ecb-8df7-7dedbaf34acf}',1,'2020-01-31 10:53:19','2020-01-31 10:53:19'),('{34fbe1f0-a1e5-4a58-9b0a-efc25e53daa3}','{de3fd19d-4583-46d1-8c97-30ef6ec5f604}',2,3,'[\"{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\"]','{2f3ff4f0-b363-40ba-990d-7b80f0df574f}',1,'2020-02-10 05:46:05','2020-02-10 05:46:05'),('{5b890fcd-7017-4474-89c8-6ba3810868f2}','{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}',10,100,'[]','{2f3ff4f0-b363-40ba-990d-7b80f0df574f}',0,'2020-01-31 05:25:01','2020-01-31 05:28:07'),('{68ae0b48-9322-4497-8952-1634fc81053e}','{e928d946-5350-4f0d-9b94-6262c39d1058}',5000,9999,'[\"{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\",\"{9ac8b41f-933e-4188-be8d-f4a5d81790d4}\",\"{a3726509-f0f1-47a1-8d1c-01d6dbd3972b}\"]','{c20cce93-c3d0-4ecb-8df7-7dedbaf34acf}',2,'2020-01-31 10:49:21','2020-01-31 10:49:21'),('{9787dda9-0d30-47fd-b3c7-3cff398cad0f}','',120,1,'[\"{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\",\"{ecbf979e-0853-4801-bda3-a60b23015750}\"]','{2f3ff4f0-b363-40ba-990d-7b80f0df574f}',2,'2020-01-31 06:23:13','2020-01-31 06:23:13'),('{9a053a72-49e0-42b8-a51c-db59895caeda}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}',100,500,'[\"{9ac8b41f-933e-4188-be8d-f4a5d81790d4}\",\"{a3726509-f0f1-47a1-8d1c-01d6dbd3972b}\",\"{4f31e556-9886-4a26-baf5-53d9defe4f6e}\",\"{01176d49-d602-46b3-bdee-ead758ccec07}\"]','{724b466c-789f-4d85-8a33-cf1136f662a0}',2,'2020-01-31 06:23:20','2020-01-31 06:23:20'),('{aa42028e-7120-4c7a-ae3d-77dac8bb1c5b}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}',12,100,'[\"{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\",\"{9ac8b41f-933e-4188-be8d-f4a5d81790d4}\",\"{77478c17-b0d9-4f97-8c40-fc3d63e238d0}\",\"{ecbf979e-0853-4801-bda3-a60b23015750}\"]','{c20cce93-c3d0-4ecb-8df7-7dedbaf34acf}',0,'2020-01-31 06:28:17','2020-01-31 06:28:17'),('{b50ebf18-0339-44a4-8fad-d0c2c88e351f}','{5df24651-ebbf-4863-b1d7-416d70f8e94b}',1,2,'[\"{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\",\"{a3726509-f0f1-47a1-8d1c-01d6dbd3972b}\"]','{c20cce93-c3d0-4ecb-8df7-7dedbaf34acf}',1,'2020-02-10 05:34:17','2020-02-10 05:34:17');
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
-- Table structure for table `HistoryItems`
--

DROP TABLE IF EXISTS `HistoryItems`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `HistoryItems` (
  `Id` varchar(38) NOT NULL,
  `UserId` varchar(38) NOT NULL,
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
INSERT INTO `HistoryItems` VALUES ('{030d08dc-afa1-4a2b-9e50-a22969fef3fc}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','MedalynxAPI.Controllers.CohortsController','Remove cohort called with id={1cfee5e3-a0bd-4380-a3c7-3f53f270e143}','0001-01-01 00:00:00'),('{218f516a-5b98-43bd-9f7b-5b7868c9d2bf}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','MedalynxAPI.Controllers.CohortsController','Remove cohort called with id={1cfee5e3-a0bd-4380-a3c7-3f53f270e143}','2020-02-11 08:46:42'),('{974997ee-9c48-4dba-9627-9d78395969e1}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','MedalynxAPI.Controllers.CohortsController','Create cohort called with data:{\"Id\":\"{1cfee5e3-a0bd-4380-a3c7-3f53f270e143}\",\"UserId\":\"{11111106-bd3a-4429-aacb-89a52f8f7950}\",\"NumberOfSubjectsRequired\":12,\"CohortType\":\"dynamic\",\"Request\":0,\"cohortEnumLinks\":[{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{47f7bac5-60e6-4161-86d9-4ec5f561cafa}\",\"EnumItemId\":null,\"Include\":1,\"Percentage\":0,\"enumItem\":{\"Id\":null,\"AgeFrom\":0,\"AgeTo\":0,\"Alt\":null,\"Chromosome\":null,\"dbSNP\":null,\"DeseaseState\":null,\"Gender\":\"mail\",\"Keyword\":null,\"Nationality\":null,\"NumberOfNodesAffected\":0,\"NumberOfMetastasis\":0,\"Position\":0,\"Ref\":null,\"StageOfTumour\":0}}]}','0001-01-01 00:00:00');
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
  `UserId` varchar(38) DEFAULT NULL,
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
INSERT INTO `Notifications` VALUES ('{8a299213-b198-459b-b8d8-e7829f6e4677}','{e928d946-5350-4f0d-9b94-6262c39d1058}','Environment request from Antony Antony',1,0,'2020-01-31 12:00:00','2020-02-05 03:31:56');
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
INSERT INTO `Sessions` VALUES ('{0bebcb4d-ddc6-4c0d-a91f-fe201c5c3d2d}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','2020-02-04 05:58:38','2020-02-04 05:58:38'),('{0de48d0c-34f6-4785-97ab-949d0a030d2d}','{57a98e8e-f5ab-4032-b647-b793b60468ff}','2020-02-05 03:19:49','2020-02-05 03:19:49'),('{74a4cf24-b830-4eab-bc90-290fce168ac3}','{de3fd19d-4583-46d1-8c97-30ef6ec5f604}','2020-02-10 05:45:53','2020-02-10 05:45:53'),('{aa219cd1-dda1-471c-920d-2a12a3b47383}','{b3643e06-bd3a-4429-aacb-89a52f8f7950}','2020-02-10 06:03:09','2020-02-10 06:03:09'),('{ea09f5d8-39a2-4b40-9c48-c26432027a3c}','{5df24651-ebbf-4863-b1d7-416d70f8e94b}','2020-02-03 10:07:42','2020-02-03 10:07:42'),('{eb439a8d-fabb-49a2-ad9b-08e2e36cd24d}','{e928d946-5350-4f0d-9b94-6262c39d1058}','2020-02-03 09:53:04','2020-02-03 09:53:04');
/*!40000 ALTER TABLE `Sessions` ENABLE KEYS */;
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
INSERT INTO `StageOfDeseases` VALUES ('{05010ff2-343f-4662-8e32-fedb13ca931e}',3,2,1),('{0ed7ebd2-7582-4c07-bf8f-f3a2d4a118b7}',1,3,4),('{20a81a7a-7b33-463d-851e-e51d88264578}',1,2,3),('{225b51c6-1a49-4cda-9345-b9979d4234cb}',1,2,3),('{29c3a7e6-1a06-4333-a14c-ff0eff2c69e1}',1,2,3),('{4131b970-6d1f-4343-b22e-5fa13867a5ca}',3,2,1),('{42511681-3320-4b70-8c8a-7b41a62edf07}',3,6,6),('{4444faff-3eb3-4584-9023-a16f6b1b5480}',3,2,1),('{52a1c759-c490-4f21-8186-de1e776354f7}',3,2,1),('{52da8eea-3c79-4f83-af3b-eae76bc74d9d}',3,2,1),('{5fd813b7-56b0-4b4a-b8a6-a4167b2fdce9}',3,6,6),('{62349259-0b52-4409-a9d5-1d2cfb9ecdfe}',1,2,3),('{6c30a953-2766-45ea-874e-9ca0d85b62e0}',1,2,3),('{8472286b-27a8-4797-b879-ff954688afc6}',1,2,3),('{941e17c0-3f46-4c3e-af38-679274a24348}',1,4,3),('{9f7fc0ea-c9cd-4434-907a-358ec0ee82b4}',3,2,1),('{a8dc5a81-c551-49e4-8a4d-e1063dfaf8e3}',3,6,6),('{c6b88d08-203d-4974-9d1f-8abc76e9ebbd}',3,2,1),('{dc3f7b72-5348-443b-a849-30eb726a7547}',3,2,1),('{de7e60ed-d90f-4879-94d4-64cef6f4d4c0}',1,2,3),('{e305d45a-4c1a-404f-896e-8888b8bfbc22}',1,2,3),('{f142b6e2-e5eb-42ba-bf2e-373cca7a19bc}',3,6,6);
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
  `Password` varchar(1024) COLLATE utf8_unicode_ci DEFAULT NULL,
  `Role` varchar(45) COLLATE utf8_unicode_ci NOT NULL DEFAULT 'STANDART_USER',
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
INSERT INTO `Users` VALUES ('{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','igor.ge@mail.ru','Igor (TEST USER)','Grebenev','Quantumsoft',0,'','STANDART_USER','2020-01-30 10:15:46','2020-01-30 10:15:46'),('{57a98e8e-f5ab-4032-b647-b793b60468ff}','medalynx@gmail.com','Admin','','',0,'admin','ADMIN','2020-02-05 01:57:22','2020-02-05 01:57:22'),('{5d6c9b90-8495-4ed7-9fa1-e88cc64d3524}','igor.grebenev@quantumsoft.ru','Igor','Grebenev','Quantumsoft Group',38,NULL,'STANDART_USER','2020-01-28 12:11:00','2020-01-28 12:16:27'),('{5df24651-ebbf-4863-b1d7-416d70f8e94b}','testusermail@mail.ru','testuser','test','',0,'12345','STANDART_USER','2020-02-03 04:35:36','2020-02-03 04:35:36'),('{7d82c349-2ab7-4b07-8830-8e598caf2b1e}','test100@mail.ru','','','',0,'','STANDART_USER','2020-01-30 10:06:16','2020-01-30 10:06:16'),('{b3643e06-bd3a-4429-aacb-89a52f8f7950}','antony@mail.ru','antony','antony','antony corporation',0,'12345','STANDART_USER','2020-02-10 06:02:57','2020-02-10 06:02:57'),('{de3fd19d-4583-46d1-8c97-30ef6ec5f604}','test@mail.ru','test1','test2','test3',0,'12345','STANDART_USER','2020-02-10 05:45:38','2020-02-10 05:45:38'),('{e928d946-5350-4f0d-9b94-6262c39d1058}','antony','antony','antony','antony',0,'antony','STANDART_USER','2020-01-31 10:46:49','2020-01-31 10:46:49');
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

-- Dump completed on 2020-02-11 15:48:45
