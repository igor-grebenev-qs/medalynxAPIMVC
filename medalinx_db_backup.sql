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
INSERT INTO `CohortEnumLink` VALUES ('{083a2a82-ab11-4798-8dc2-fe0a8fec3762}','{f4fb181a-66e6-45e4-8d51-5c3215a691d0}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{f132a112-030b-423e-a304-69748cad26d5}',0,0,'2020-02-12 08:58:06','2020-02-12 08:58:06'),('{0df0bc37-c6b5-40fd-bf61-097be9111057}','{f4fb181a-66e6-45e4-8d51-5c3215a691d0}','{f1c60ef6-f4cc-45c6-9dc3-e53d9edc14c5}','{1b48b566-2323-4f84-9f13-311a189dbea7}',1,0,'2020-02-12 08:58:16','2020-02-12 08:58:16'),('{11390803-6fc2-47d0-a2e7-1020a1d6fd6b}','{f4fb181a-66e6-45e4-8d51-5c3215a691d0}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{1c308f58-c3e0-450d-91f4-9c5543129d42}',1,0,'2020-02-12 08:58:09','2020-02-12 08:58:09'),('{135db1fb-ce48-4132-ac3e-b761c0824521}','{6846a046-3a29-46f6-b7a1-406310534ac0}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{5f6617d5-1cd7-4606-8eee-5a7534a94001}',0,0,'2020-02-14 09:24:59','2020-02-14 09:24:59'),('{14df71c8-464c-4821-be01-9a43517b2948}','{bae4f9cc-752e-4935-b8f9-6a2cd5b8e346}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{2990b095-ad97-4144-a69f-b8007aa78ed3}',1,0,'2020-02-13 09:35:38','2020-02-13 09:35:38'),('{1d971cb6-85e3-4058-ab61-d993254a60eb}','{6846a046-3a29-46f6-b7a1-406310534ac0}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{74e05cd7-8b87-4b34-86a0-73cac65db1a5}',1,0,'2020-02-14 09:25:09','2020-02-14 09:25:09'),('{2352c368-570b-442b-8962-1c02aed0c984}','{6846a046-3a29-46f6-b7a1-406310534ac0}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{f132a112-030b-423e-a304-69748cad26d5}',0,0,'2020-02-14 09:25:04','2020-02-14 09:25:04'),('{2a592818-fbdb-4ff1-8581-89fc4b1f233c}','{bae4f9cc-752e-4935-b8f9-6a2cd5b8e346}','{47f7bac5-60e6-4161-86d9-4ec5f561cafa}','{33510542-1210-41c1-9a50-c57a557dab22}',0,0,'2020-02-13 09:35:46','2020-02-13 09:35:46'),('{2db51a57-4927-4e5e-82e3-b4a42f1132c0}','{6846a046-3a29-46f6-b7a1-406310534ac0}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{1c308f58-c3e0-450d-91f4-9c5543129d42}',0,0,'2020-02-14 09:25:02','2020-02-14 09:25:02'),('{4581a17c-bfe4-468e-b101-5b2637a0f1b1}','{6846a046-3a29-46f6-b7a1-406310534ac0}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{4047257e-ca3d-4b47-ac1d-9ff49801d388}',1,0,'2020-02-14 09:24:56','2020-02-14 09:24:56'),('{4d387223-e8ea-446a-82c0-ecec7c4809c4}','{f4fb181a-66e6-45e4-8d51-5c3215a691d0}','{5d65643e-4060-48e3-a094-347133b0ed81}','{3eb9d916-1a66-495d-9ba9-3f28f4510daf}',0,0,'2020-02-12 08:58:17','2020-02-12 08:58:17'),('{501f9723-3509-4e1f-9e56-9d012b6e6602}','{6846a046-3a29-46f6-b7a1-406310534ac0}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{2990b095-ad97-4144-a69f-b8007aa78ed3}',1,0,'2020-02-14 09:24:58','2020-02-14 09:24:58'),('{527aaf73-5ae5-4cdd-b7e7-38f629aa8966}','{5f8a57c9-989f-46ee-b1c3-98086a73ee6e}','{5d65643e-4060-48e3-a094-347133b0ed81}','{3eb9d916-1a66-495d-9ba9-3f28f4510daf}',1,0,'2020-02-12 10:55:48','2020-02-12 10:55:48'),('{54851f94-2e0d-4a0a-9048-e80343917ee2}','{5f8a57c9-989f-46ee-b1c3-98086a73ee6e}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{3399fdb9-f33c-4532-8fc4-cd370fde592e}',1,0,'2020-02-12 10:55:43','2020-02-12 10:55:43'),('{5611034c-4b8f-4216-b1e7-0496df3ca8b6}','{f4fb181a-66e6-45e4-8d51-5c3215a691d0}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{74e05cd7-8b87-4b34-86a0-73cac65db1a5}',0,0,'2020-02-12 08:58:11','2020-02-12 08:58:11'),('{596b39e2-e086-45c9-b240-f83b6e4e280d}','{bae4f9cc-752e-4935-b8f9-6a2cd5b8e346}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{3399fdb9-f33c-4532-8fc4-cd370fde592e}',1,0,'2020-02-13 09:35:41','2020-02-13 09:35:41'),('{5afea90d-a925-497e-8789-8946fdf350ec}','{f4fb181a-66e6-45e4-8d51-5c3215a691d0}','{cc77ecca-8279-4c9d-b321-064ba492ba9e}','{3c918a69-9eb6-4fb7-bab7-3d846079d88f}',0,0,'2020-02-12 08:58:29','2020-02-12 08:58:29'),('{6719b73b-0766-4038-a41e-3bc9e090bfb4}','{bae4f9cc-752e-4935-b8f9-6a2cd5b8e346}','{f1c60ef6-f4cc-45c6-9dc3-e53d9edc14c5}','{1b48b566-2323-4f84-9f13-311a189dbea7}',1,0,'2020-02-13 09:35:42','2020-02-13 09:35:42'),('{76d7de10-82e3-4ac8-947e-128fb209c1dc}','{6846a046-3a29-46f6-b7a1-406310534ac0}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{3399fdb9-f33c-4532-8fc4-cd370fde592e}',1,0,'2020-02-14 09:25:06','2020-02-14 09:25:06'),('{826f8c01-d7e1-47ef-a4d4-07eb6724fca8}','{6846a046-3a29-46f6-b7a1-406310534ac0}','{f1c60ef6-f4cc-45c6-9dc3-e53d9edc14c5}','{1b48b566-2323-4f84-9f13-311a189dbea7}',1,0,'2020-02-14 09:25:10','2020-02-14 09:25:10'),('{82c4a8b2-be29-4bca-b5b7-84d447e085e5}','{5f8a57c9-989f-46ee-b1c3-98086a73ee6e}','{3089e988-cbaa-4417-9ff2-447a3d90a534}','{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}',0,0,'2020-02-12 10:55:39','2020-02-12 10:55:39'),('{84179e5a-055a-45de-b052-bac3f094fa6e}','{f4fb181a-66e6-45e4-8d51-5c3215a691d0}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{3399fdb9-f33c-4532-8fc4-cd370fde592e}',0,0,'2020-02-12 08:58:13','2020-02-12 08:58:13'),('{8502dc3f-b598-4aa7-9ccc-a56ff1623b12}','{bae4f9cc-752e-4935-b8f9-6a2cd5b8e346}','{cc77ecca-8279-4c9d-b321-064ba492ba9e}','{a21da587-f94e-47e2-af2c-f5b2d1fd422e}',0,0,'2020-02-13 09:35:48','2020-02-13 09:35:48'),('{8914e7c5-1a73-4c97-879b-f868887fd1a3}','{5f8a57c9-989f-46ee-b1c3-98086a73ee6e}','{152583bb-7105-462e-ad74-c9702696feae}','{0eb27144-8c1c-4ad6-a513-ce109fc735ec}',0,0,'2020-02-12 10:55:50','2020-02-12 10:55:50'),('{8a7ed977-f6fc-4d10-8c4d-ea8704768934}','{5f8a57c9-989f-46ee-b1c3-98086a73ee6e}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{92f64a21-6170-4019-8cc8-917ab7e8b4dd}',0,0,'2020-02-12 10:55:47','2020-02-12 10:55:47'),('{8c64fb2e-2c7f-42a6-b88a-cbd0a3149d46}','{f4fb181a-66e6-45e4-8d51-5c3215a691d0}','{cc77ecca-8279-4c9d-b321-064ba492ba9e}','{1220c8de-8319-405b-a27a-f6993c2216e0}',1,0,'2020-02-12 08:58:27','2020-02-12 08:58:27'),('{97af46c6-36c4-48fd-98e9-7e4831ebd78c}','{6846a046-3a29-46f6-b7a1-406310534ac0}','{5d65643e-4060-48e3-a094-347133b0ed81}','{3eb9d916-1a66-495d-9ba9-3f28f4510daf}',1,0,'2020-02-14 09:25:12','2020-02-14 09:25:12'),('{97f2d3f9-7bd8-4dc7-b219-742059b5b79f}','{6846a046-3a29-46f6-b7a1-406310534ac0}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{7b1b6585-e9dd-4d17-9ef0-af179246e2b3}',0,0,'2020-02-14 09:25:07','2020-02-14 09:25:07'),('{9dffce6f-5450-4bfa-bbc9-e7147bda3e7d}','{f4fb181a-66e6-45e4-8d51-5c3215a691d0}','{47f7bac5-60e6-4161-86d9-4ec5f561cafa}','{8ab3839a-e06b-4db4-b3a4-16ca40b3f856}',1,0,'2020-02-12 08:58:24','2020-02-12 08:58:24'),('{a9921f2b-cac7-43c3-99a4-9a20367066d4}','{5f8a57c9-989f-46ee-b1c3-98086a73ee6e}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{74e05cd7-8b87-4b34-86a0-73cac65db1a5}',1,0,'2020-02-12 10:55:45','2020-02-12 10:55:45'),('{ab01ccc3-66fb-4f83-b52d-ac2f84a61ab1}','{5f8a57c9-989f-46ee-b1c3-98086a73ee6e}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{555babc2-3a1d-4025-b835-a8098945726c}',1,0,'2020-02-12 10:55:42','2020-02-12 10:55:42'),('{bd6be4a2-50b6-4ae6-b6a6-813779d7cbac}','{f4fb181a-66e6-45e4-8d51-5c3215a691d0}','{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}','{7b1b6585-e9dd-4d17-9ef0-af179246e2b3}',0,0,'2020-02-12 08:58:14','2020-02-12 08:58:14'),('{bf1958bc-a593-43b5-a8b2-e56408313eab}','{bae4f9cc-752e-4935-b8f9-6a2cd5b8e346}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{1c308f58-c3e0-450d-91f4-9c5543129d42}',0,0,'2020-02-13 09:35:40','2020-02-13 09:35:40'),('{ca10306d-2589-4923-8d83-92c9699d393d}','{6846a046-3a29-46f6-b7a1-406310534ac0}','{47f7bac5-60e6-4161-86d9-4ec5f561cafa}','{415de6cd-76c2-423c-ab9b-8b651db3ecff}',1,0,'2020-02-14 09:25:15','2020-02-14 09:25:15'),('{cc8d3af6-0418-4ba2-98dd-4d909585d709}','{bae4f9cc-752e-4935-b8f9-6a2cd5b8e346}','{5d65643e-4060-48e3-a094-347133b0ed81}','{3eb9d916-1a66-495d-9ba9-3f28f4510daf}',1,0,'2020-02-13 09:35:43','2020-02-13 09:35:43'),('{ce1ad429-5316-416b-972e-07e06a8a9435}','{5f8a57c9-989f-46ee-b1c3-98086a73ee6e}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{5f6617d5-1cd7-4606-8eee-5a7534a94001}',0,0,'2020-02-12 10:55:40','2020-02-12 10:55:40'),('{cfddf6b5-f96c-4796-a1df-8bedeef9da2f}','{f4fb181a-66e6-45e4-8d51-5c3215a691d0}','{47f7bac5-60e6-4161-86d9-4ec5f561cafa}','{5246ee91-e8c3-4154-99e9-3ea55dc8f075}',0,0,'2020-02-12 08:58:22','2020-02-12 08:58:22'),('{d03b67b4-400d-41ee-b0a5-ff6dbfec4306}','{f4fb181a-66e6-45e4-8d51-5c3215a691d0}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{555babc2-3a1d-4025-b835-a8098945726c}',0,0,'2020-02-12 08:58:08','2020-02-12 08:58:08'),('{d807a03f-851a-42a6-b9aa-a5ab42454d4e}','{5f8a57c9-989f-46ee-b1c3-98086a73ee6e}','{47f7bac5-60e6-4161-86d9-4ec5f561cafa}','{6acff94c-384c-4930-8b50-cf55cdf11b28}',0,0,'2020-02-12 10:55:52','2020-02-12 10:55:52'),('{ebc62a4c-5ef8-4057-bcbf-ace52ab45dc6}','{f4fb181a-66e6-45e4-8d51-5c3215a691d0}','{152583bb-7105-462e-ad74-c9702696feae}','{0eb27144-8c1c-4ad6-a513-ce109fc735ec}',1,0,'2020-02-12 08:58:19','2020-02-12 08:58:19'),('{ee629e8d-f020-4f12-93d0-ec8d9597fe49}','{6846a046-3a29-46f6-b7a1-406310534ac0}','{cc77ecca-8279-4c9d-b321-064ba492ba9e}','{f7a41b08-5868-4e51-8fb5-306a8ffd497d}',1,0,'2020-02-14 09:25:17','2020-02-14 09:25:17'),('{f614c9e6-4709-4552-9bdb-c64f946767bf}','{6846a046-3a29-46f6-b7a1-406310534ac0}','{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}','{555babc2-3a1d-4025-b835-a8098945726c}',0,0,'2020-02-14 09:25:01','2020-02-14 09:25:01'),('{fcbbcc18-402d-43bd-b46d-dbb1661ee152}','{5f8a57c9-989f-46ee-b1c3-98086a73ee6e}','{cc77ecca-8279-4c9d-b321-064ba492ba9e}','{0bb88459-7e3c-4eb1-acfa-90fe8a17fecd}',1,0,'2020-02-12 10:55:55','2020-02-12 10:55:55'),('{fe1f8fa5-5e50-4909-b0ad-fe370f8dc1bc}','{bae4f9cc-752e-4935-b8f9-6a2cd5b8e346}','{152583bb-7105-462e-ad74-c9702696feae}','{0eb27144-8c1c-4ad6-a513-ce109fc735ec}',0,0,'2020-02-13 09:35:44','2020-02-13 09:35:44');
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
  `RequestAdmin` int(11) DEFAULT 0,
  `RequestUser` int(11) DEFAULT 0,
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
INSERT INTO `Cohorts` VALUES ('{5f8a57c9-989f-46ee-b1c3-98086a73ee6e}','{49fffec7-48e4-4bbf-83b8-ee85e97051c5}',100111,'static',0,20,'2020-02-12 10:39:14','2020-02-12 10:56:28'),('{6846a046-3a29-46f6-b7a1-406310534ac0}','{f62a2c71-77db-4166-bad8-5ff2676ac21b}',3,'dynamic',0,0,'2020-02-14 08:50:31','2020-02-14 09:24:44'),('{bae4f9cc-752e-4935-b8f9-6a2cd5b8e346}','{bde09723-429a-4d20-a0e1-ab1672936243}',100,'dynamic',0,0,'2020-02-13 09:35:37','2020-02-13 09:35:37'),('{f4fb181a-66e6-45e4-8d51-5c3215a691d0}','{b3643e06-bd3a-4429-aacb-89a52f8f7950}',1000,'dynamic',0,20,'2020-02-12 08:32:34','2020-02-12 08:59:34');
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
INSERT INTO `Demographics` VALUES ('{054ac310-d802-425b-ab9a-b8e2ff4c6480}',1,2,'0'),('{16ec1134-d161-48a7-ace7-032fd8922f39}',1,23,'0'),('{25c9a9b5-de54-46de-94e7-02614535e4a1}',1,100,'2'),('{33510542-1210-41c1-9a50-c57a557dab22}',1,2,'2'),('{3f4a8111-c6cb-4a9d-9098-909a4d768391}',2,4,'2'),('{415de6cd-76c2-423c-ab9b-8b651db3ecff}',1,23,'0'),('{4181faac-87b3-4c96-a253-0d5f4b731273}',1,23,'0'),('{42ad78a3-f9d7-4c52-a4fc-976cb6cf0b1e}',1,100,'2'),('{5246ee91-e8c3-4154-99e9-3ea55dc8f075}',2,4,'2'),('{56d33514-2abd-42c6-8592-57e11c8463ad}',32,123,'2'),('{57135856-1195-4f49-a1b0-9375248eb2f4}',1,100,'2'),('{6238f020-b4df-45ee-9ae3-ae5bd41222b1}',32,123,'2'),('{626eeb52-355e-4ce8-9d4f-98b9363c9ed7}',1,23,'0'),('{6a0efc04-cb37-4e2a-8f33-80c4899e9f4c}',1,15,'0'),('{6acff94c-384c-4930-8b50-cf55cdf11b28}',1,2,'0'),('{82eeeb21-5673-4b1a-a32d-b05fd0144d5a}',1,23,'0'),('{893c1a59-835e-4a3c-a381-e97e6e7b907b}',1,2,'0'),('{8ab3839a-e06b-4db4-b3a4-16ca40b3f856}',1,2,'0'),('{8c96e9e7-39e2-4455-99b1-4d9fe7fb63f7}',1,2,'0'),('{90703b83-8914-4084-b545-882cb36c3cf9}',1,2,'0'),('{965ab8fd-42c1-4aef-9137-7d25a984d26e}',1,2,'0'),('{acac16e8-0949-4ba5-811d-63f93ac27c99}',1,2,'0'),('{aea9628b-f299-4846-9575-50fad724cbc2}',1,100,'2'),('{b2746890-7ee6-49d0-8894-50e93e45d64d}',2,4,'2'),('{b32d319e-63a1-4569-b118-dad6a8598945}',1,100,'2'),('{bb2b3574-9afa-4d1c-8955-d65f694232e6}',1,2,'0'),('{be098cb4-896d-4f44-bd0d-7e0046040c2b}',2,4,'2'),('{c3f95bfb-6a4b-49f5-8d55-42f1c84bcbcd}',1,2,'0'),('{c9ae82d0-b4c8-42e5-81c9-be9a07306b14}',2,4,'2'),('{d13a1376-93ce-4730-9ca8-0af258995b5d}',1,2,'0'),('{dd312d9b-8f5b-4123-a40d-0880b8e4625c}',1,100,'2'),('{e1508c52-9fc2-42d8-a5eb-fd9b264bf52e}',1,2,'0'),('{e1fb51e2-b159-43a2-a5e0-18d8a57cd664}',1,2,'0'),('{efd8df55-8f49-4ade-8bdd-f61e4102925b}',32,123,'2'),('{fb2a0551-7e4b-497b-99f2-bc3d3bbe0ba7}',1,2,'0');
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
INSERT INTO `DeseaseStates` VALUES ('{2990b095-ad97-4144-a69f-b8007aa78ed3}','Salmonella septicaemia'),('{4047257e-ca3d-4b47-ac1d-9ff49801d388}','Localised Salmonella infections'),('{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}','Paratyphoid fever A'),('{f14840b5-46c2-46e8-a92c-f9b2dbc5dbd7}','Salmonella gastro-enteritis');
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
  `AnalyticalApplication` longtext NOT NULL COMMENT 'Array of analytical applications',
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
INSERT INTO `Enviroments` VALUES ('{104a266b-1fe9-4477-856f-5c09859c7515}','{b3643e06-bd3a-4429-aacb-89a52f8f7950}',1,2,'[\"{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\",\"{a3726509-f0f1-47a1-8d1c-01d6dbd3972b}\",\"{9ac8b41f-933e-4188-be8d-f4a5d81790d4}\"]','{c20cce93-c3d0-4ecb-8df7-7dedbaf34acf}',20,'2020-02-12 08:27:31','2020-02-12 08:27:31'),('{74e69965-b6fd-4d68-960f-1ee82cedea19}','{bde09723-429a-4d20-a0e1-ab1672936243}',1,99955,'[\"{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\",\"{9ac8b41f-933e-4188-be8d-f4a5d81790d4}\"]','{2f3ff4f0-b363-40ba-990d-7b80f0df574f}',20,'2020-02-13 08:58:55','2020-02-13 08:58:55'),('{83ea596f-9ca9-4374-b5d4-e2baedc4452d}','{f62a2c71-77db-4166-bad8-5ff2676ac21b}',123,321,'[\"{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\"]','{2f3ff4f0-b363-40ba-990d-7b80f0df574f}',20,'2020-02-14 08:31:36','2020-02-14 08:31:36'),('{91de9e37-e9fd-42f8-89b3-4f21847deca1}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}',12,22,'[\"{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\",\"{029352de-a17b-4ce0-b350-02702e67cf55}\",\"{6b9a507e-3340-4d64-8fd9-908a69c00f6d}\"]','{2f3ff4f0-b363-40ba-990d-7b80f0df574f}',0,'2020-02-13 11:37:46','2020-02-13 11:37:46'),('{f436e443-17b6-49bc-8fd2-4360f132bc64}','{49fffec7-48e4-4bbf-83b8-ee85e97051c5}',1,2,'[\"{c5e4dfe7-83ed-439c-9ec2-68f9ee059896}\",\"{a3726509-f0f1-47a1-8d1c-01d6dbd3972b}\"]','{2f3ff4f0-b363-40ba-990d-7b80f0df574f}',20,'2020-02-12 10:09:10','2020-02-12 10:09:10');
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
INSERT INTO `HistoryItems` VALUES ('{17488541-30e2-4ad8-8b25-c1634190f748}','{b3643e06-bd3a-4429-aacb-89a52f8f7950}','MedalynxAPI.Controllers.CohortsController','Create cohort called with data:{\"Id\":\"{f4fb181a-66e6-45e4-8d51-5c3215a691d0}\",\"UserId\":\"{b3643e06-bd3a-4429-aacb-89a52f8f7950}\",\"NumberOfSubjectsRequired\":100,\"CohortType\":\"dynamic\",\"Request\":0,\"cohortEnumLinks\":[{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{2990b095-ad97-4144-a69f-b8007aa78ed3}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{4047257e-ca3d-4b47-ac1d-9ff49801d388}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}\",\"EnumItemId\":\"{1c308f58-c3e0-450d-91f4-9c5543129d42}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}\",\"EnumItemId\":\"{555babc2-3a1d-4025-b835-a8098945726c}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}\",\"EnumItemId\":\"{3399fdb9-f33c-4532-8fc4-cd370fde592e}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}\",\"EnumItemId\":\"{74e05cd7-8b87-4b34-86a0-73cac65db1a5}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}\",\"EnumItemId\":\"{7b1b6585-e9dd-4d17-9ef0-af179246e2b3}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{f1c60ef6-f4cc-45c6-9dc3-e53d9edc14c5}\",\"EnumItemId\":\"{1b48b566-2323-4f84-9f13-311a189dbea7}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{5d65643e-4060-48e3-a094-347133b0ed81}\",\"EnumItemId\":\"{3eb9d916-1a66-495d-9ba9-3f28f4510daf}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{152583bb-7105-462e-ad74-c9702696feae}\",\"EnumItemId\":\"{0eb27144-8c1c-4ad6-a513-ce109fc735ec}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{47f7bac5-60e6-4161-86d9-4ec5f561cafa}\",\"EnumItemId\":null,\"Include\":1,\"Percentage\":0,\"enumItem\":{\"Id\":null,\"AgeFrom\":1,\"AgeTo\":2,\"Alt\":null,\"Chromosome\":null,\"dbSNP\":null,\"DeseaseState\":null,\"Gender\":\"0\",\"Keyword\":null,\"Nationality\":null,\"NumberOfNodesAffected\":0,\"NumberOfMetastasis\":0,\"Position\":0,\"Ref\":null,\"StageOfTumour\":0}},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{47f7bac5-60e6-4161-86d9-4ec5f561cafa}\",\"EnumItemId\":null,\"Include\":0,\"Percentage\":0,\"enumItem\":{\"Id\":null,\"AgeFrom\":2,\"AgeTo\":4,\"Alt\":null,\"Chromosome\":null,\"dbSNP\":null,\"DeseaseState\":null,\"Gender\":\"2\",\"Keyword\":null,\"Nationality\":null,\"NumberOfNodesAffected\":0,\"NumberOfMetastasis\":0,\"Position\":0,\"Ref\":null,\"StageOfTumour\":0}},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{cc77ecca-8279-4c9d-b321-064ba492ba9e}\",\"EnumItemId\":null,\"Include\":1,\"Percentage\":0,\"enumItem\":{\"Id\":null,\"AgeFrom\":0,\"AgeTo\":0,\"Alt\":null,\"Chromosome\":null,\"dbSNP\":null,\"DeseaseState\":null,\"Gender\":null,\"Keyword\":null,\"Nationality\":null,\"NumberOfNodesAffected\":2,\"NumberOfMetastasis\":3,\"Position\":0,\"Ref\":null,\"StageOfTumour\":1}},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{cc77ecca-8279-4c9d-b321-064ba492ba9e}\",\"EnumItemId\":null,\"Include\":0,\"Percentage\":0,\"enumItem\":{\"Id\":null,\"AgeFrom\":0,\"AgeTo\":0,\"Alt\":null,\"Chromosome\":null,\"dbSNP\":null,\"DeseaseState\":null,\"Gender\":null,\"Keyword\":null,\"Nationality\":null,\"NumberOfNodesAffected\":2,\"NumberOfMetastasis\":1,\"Position\":0,\"Ref\":null,\"StageOfTumour\":3}}]}','2020-02-12 08:32:33'),('{3b5b6c9f-c159-49b7-bc93-b50065ad03d7}','{49fffec7-48e4-4bbf-83b8-ee85e97051c5}','MedalynxAPI.Controllers.CohortsController','Create cohort called with data:{\"Id\":\"{5f8a57c9-989f-46ee-b1c3-98086a73ee6e}\",\"UserId\":\"{49fffec7-48e4-4bbf-83b8-ee85e97051c5}\",\"NumberOfSubjectsRequired\":1,\"CohortType\":\"dynamic\",\"Request\":0,\"cohortEnumLinks\":[{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{2990b095-ad97-4144-a69f-b8007aa78ed3}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{4047257e-ca3d-4b47-ac1d-9ff49801d388}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{f14840b5-46c2-46e8-a92c-f9b2dbc5dbd7}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}\",\"EnumItemId\":\"{1c308f58-c3e0-450d-91f4-9c5543129d42}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}\",\"EnumItemId\":\"{555babc2-3a1d-4025-b835-a8098945726c}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}\",\"EnumItemId\":\"{5f6617d5-1cd7-4606-8eee-5a7534a94001}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}\",\"EnumItemId\":\"{f132a112-030b-423e-a304-69748cad26d5}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{f1c60ef6-f4cc-45c6-9dc3-e53d9edc14c5}\",\"EnumItemId\":\"{1b48b566-2323-4f84-9f13-311a189dbea7}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{152583bb-7105-462e-ad74-c9702696feae}\",\"EnumItemId\":\"{0eb27144-8c1c-4ad6-a513-ce109fc735ec}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{47f7bac5-60e6-4161-86d9-4ec5f561cafa}\",\"EnumItemId\":null,\"Include\":1,\"Percentage\":0,\"enumItem\":{\"Id\":null,\"AgeFrom\":1,\"AgeTo\":2,\"Alt\":null,\"Chromosome\":null,\"dbSNP\":null,\"DeseaseState\":null,\"Gender\":\"0\",\"Keyword\":null,\"Nationality\":null,\"NumberOfNodesAffected\":0,\"NumberOfMetastasis\":0,\"Position\":0,\"Ref\":null,\"StageOfTumour\":0}},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{47f7bac5-60e6-4161-86d9-4ec5f561cafa}\",\"EnumItemId\":null,\"Include\":1,\"Percentage\":0,\"enumItem\":{\"Id\":null,\"AgeFrom\":1,\"AgeTo\":100,\"Alt\":null,\"Chromosome\":null,\"dbSNP\":null,\"DeseaseState\":null,\"Gender\":\"2\",\"Keyword\":null,\"Nationality\":null,\"NumberOfNodesAffected\":0,\"NumberOfMetastasis\":0,\"Position\":0,\"Ref\":null,\"StageOfTumour\":0}}]}','2020-02-12 10:39:13'),('{9bbff2a8-3060-4d70-8058-11fc8f1b581c}','{f62a2c71-77db-4166-bad8-5ff2676ac21b}','MedalynxAPI.Controllers.CohortsController','Create cohort called with data:{\"Id\":\"{6846a046-3a29-46f6-b7a1-406310534ac0}\",\"UserId\":\"{f62a2c71-77db-4166-bad8-5ff2676ac21b}\",\"NumberOfSubjectsRequired\":3,\"CohortType\":\"dynamic\",\"Request\":0,\"cohortEnumLinks\":[{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{4047257e-ca3d-4b47-ac1d-9ff49801d388}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{2990b095-ad97-4144-a69f-b8007aa78ed3}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{5197faa8-c0c3-4f47-981c-6fb7fb7aab7a}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}\",\"EnumItemId\":\"{1c308f58-c3e0-450d-91f4-9c5543129d42}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}\",\"EnumItemId\":\"{555babc2-3a1d-4025-b835-a8098945726c}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}\",\"EnumItemId\":\"{5f6617d5-1cd7-4606-8eee-5a7534a94001}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}\",\"EnumItemId\":\"{f132a112-030b-423e-a304-69748cad26d5}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}\",\"EnumItemId\":\"{74e05cd7-8b87-4b34-86a0-73cac65db1a5}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}\",\"EnumItemId\":\"{7b1b6585-e9dd-4d17-9ef0-af179246e2b3}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}\",\"EnumItemId\":\"{3399fdb9-f33c-4532-8fc4-cd370fde592e}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{f1c60ef6-f4cc-45c6-9dc3-e53d9edc14c5}\",\"EnumItemId\":\"{1b48b566-2323-4f84-9f13-311a189dbea7}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{5d65643e-4060-48e3-a094-347133b0ed81}\",\"EnumItemId\":\"{3eb9d916-1a66-495d-9ba9-3f28f4510daf}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{152583bb-7105-462e-ad74-c9702696feae}\",\"EnumItemId\":\"{0eb27144-8c1c-4ad6-a513-ce109fc735ec}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{47f7bac5-60e6-4161-86d9-4ec5f561cafa}\",\"EnumItemId\":null,\"Include\":1,\"Percentage\":0,\"enumItem\":{\"Id\":null,\"AgeFrom\":1,\"AgeTo\":23,\"Alt\":null,\"Chromosome\":null,\"dbSNP\":null,\"DeseaseState\":null,\"Gender\":\"0\",\"Keyword\":null,\"Nationality\":null,\"NumberOfNodesAffected\":0,\"NumberOfMetastasis\":0,\"Position\":0,\"Ref\":null,\"StageOfTumour\":0}},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{47f7bac5-60e6-4161-86d9-4ec5f561cafa}\",\"EnumItemId\":null,\"Include\":1,\"Percentage\":0,\"enumItem\":{\"Id\":null,\"AgeFrom\":32,\"AgeTo\":123,\"Alt\":null,\"Chromosome\":null,\"dbSNP\":null,\"DeseaseState\":null,\"Gender\":\"2\",\"Keyword\":null,\"Nationality\":null,\"NumberOfNodesAffected\":0,\"NumberOfMetastasis\":0,\"Position\":0,\"Ref\":null,\"StageOfTumour\":0}},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{cc77ecca-8279-4c9d-b321-064ba492ba9e}\",\"EnumItemId\":null,\"Include\":1,\"Percentage\":0,\"enumItem\":{\"Id\":null,\"AgeFrom\":0,\"AgeTo\":0,\"Alt\":null,\"Chromosome\":null,\"dbSNP\":null,\"DeseaseState\":null,\"Gender\":null,\"Keyword\":null,\"Nationality\":null,\"NumberOfNodesAffected\":3,\"NumberOfMetastasis\":2,\"Position\":0,\"Ref\":null,\"StageOfTumour\":1}}]}','2020-02-14 08:50:30'),('{bcdc621e-a017-4ae2-bc97-51c550527187}','{bde09723-429a-4d20-a0e1-ab1672936243}','MedalynxAPI.Controllers.CohortsController','Create cohort called with data:{\"Id\":\"{bae4f9cc-752e-4935-b8f9-6a2cd5b8e346}\",\"UserId\":\"{bde09723-429a-4d20-a0e1-ab1672936243}\",\"NumberOfSubjectsRequired\":100,\"CohortType\":\"dynamic\",\"Request\":0,\"cohortEnumLinks\":[{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{3089e988-cbaa-4417-9ff2-447a3d90a534}\",\"EnumItemId\":\"{2990b095-ad97-4144-a69f-b8007aa78ed3}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{441ae4d5-6bac-4ff2-9153-4fa88393a7e6}\",\"EnumItemId\":\"{1c308f58-c3e0-450d-91f4-9c5543129d42}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{bc70c1e5-04ff-40ef-a80f-f5911f99bfc4}\",\"EnumItemId\":\"{3399fdb9-f33c-4532-8fc4-cd370fde592e}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{f1c60ef6-f4cc-45c6-9dc3-e53d9edc14c5}\",\"EnumItemId\":\"{1b48b566-2323-4f84-9f13-311a189dbea7}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{5d65643e-4060-48e3-a094-347133b0ed81}\",\"EnumItemId\":\"{3eb9d916-1a66-495d-9ba9-3f28f4510daf}\",\"Include\":1,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{152583bb-7105-462e-ad74-c9702696feae}\",\"EnumItemId\":\"{0eb27144-8c1c-4ad6-a513-ce109fc735ec}\",\"Include\":0,\"Percentage\":0,\"enumItem\":null},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{47f7bac5-60e6-4161-86d9-4ec5f561cafa}\",\"EnumItemId\":null,\"Include\":0,\"Percentage\":0,\"enumItem\":{\"Id\":null,\"AgeFrom\":1,\"AgeTo\":2,\"Alt\":null,\"Chromosome\":null,\"dbSNP\":null,\"DeseaseState\":null,\"Gender\":\"2\",\"Keyword\":null,\"Nationality\":null,\"NumberOfNodesAffected\":0,\"NumberOfMetastasis\":0,\"Position\":0,\"Ref\":null,\"StageOfTumour\":0}},{\"Id\":null,\"CohortId\":null,\"CohortEnumId\":\"{cc77ecca-8279-4c9d-b321-064ba492ba9e}\",\"EnumItemId\":null,\"Include\":0,\"Percentage\":0,\"enumItem\":{\"Id\":null,\"AgeFrom\":0,\"AgeTo\":0,\"Alt\":null,\"Chromosome\":null,\"dbSNP\":null,\"DeseaseState\":null,\"Gender\":null,\"Keyword\":null,\"Nationality\":null,\"NumberOfNodesAffected\":2,\"NumberOfMetastasis\":3,\"Position\":0,\"Ref\":null,\"StageOfTumour\":1}}]}','2020-02-13 09:35:36');
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
INSERT INTO `Sessions` VALUES ('{0bebcb4d-ddc6-4c0d-a91f-fe201c5c3d2d}','{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','2020-02-04 05:58:38','2020-02-04 05:58:38'),('{0de48d0c-34f6-4785-97ab-949d0a030d2d}','{57a98e8e-f5ab-4032-b647-b793b60468ff}','2020-02-05 03:19:49','2020-02-05 03:19:49'),('{38367e38-05ec-4a6a-833d-94358aaf877a}','{bde09723-429a-4d20-a0e1-ab1672936243}','2020-02-12 09:59:04','2020-02-12 09:59:04'),('{8f68831d-50a3-4584-bdce-b11bf8ae8767}','{e8d62dd6-59d4-4029-a1b1-248da6f933e4}','2020-02-14 07:48:54','2020-02-14 07:48:54'),('{9785b913-402a-4a2b-9f51-01e124ca005e}','{49fffec7-48e4-4bbf-83b8-ee85e97051c5}','2020-02-12 10:07:35','2020-02-12 10:07:35'),('{aa219cd1-dda1-471c-920d-2a12a3b47383}','{b3643e06-bd3a-4429-aacb-89a52f8f7950}','2020-02-10 06:03:09','2020-02-10 06:03:09'),('{bf85f851-c8e7-4d03-b1df-a3c1edcfe4f8}','{756f72f3-5150-4e85-b02a-a3f0ab23e07e}','2020-02-12 10:01:23','2020-02-12 10:01:23'),('{c2f1db3e-8db0-442a-8d71-d6a555cd8c84}','{f62a2c71-77db-4166-bad8-5ff2676ac21b}','2020-02-12 10:00:18','2020-02-12 10:00:18');
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
INSERT INTO `StageOfDeseases` VALUES ('{0bb88459-7e3c-4eb1-acfa-90fe8a17fecd}',1,2,3),('{11bab309-9f64-4c0b-ba46-22bb4cf6144b}',1,2,3),('{1220c8de-8319-405b-a27a-f6993c2216e0}',1,2,3),('{15bb3b46-7a8b-4ebe-ad16-72647d9e1bcc}',1,3,2),('{18272704-c5c5-4261-8312-74512420802e}',1,2,3),('{1e5be500-78ed-4add-bcf7-a062b0b35640}',1,2,3),('{2a668aab-e34a-4945-9b5f-38cfab7057cd}',1,2,3),('{3c918a69-9eb6-4fb7-bab7-3d846079d88f}',3,2,1),('{3fded15a-ace2-4811-bf40-b7576c454855}',3,2,1),('{408851da-db06-4925-a57c-e03edfc50d62}',1,2,3),('{420e7770-218c-4fa3-9cbe-8be9f06e73cb}',1,2,3),('{4ab67ad3-bee2-4133-bd7c-3991680e5a9a}',3,2,1),('{4d0a3fb5-f2f9-4b1b-81c2-c4b87a4a7901}',1,2,3),('{5260c6c6-3494-4996-a525-2df7253b6613}',1,3,2),('{787395da-2b14-4b81-ab46-e1bc85ec9d78}',3,2,1),('{79ec7d09-1674-4a9e-885e-365f716c8c0b}',1,3,2),('{7ff20e5f-ca0a-4147-b6c3-cd9325262e93}',3,2,1),('{a21da587-f94e-47e2-af2c-f5b2d1fd422e}',1,2,3),('{c6f3938f-55cd-4a50-8e7c-a555b770b3a1}',3,2,1),('{cf14a886-c3c7-4666-89ee-a8c71f982270}',3,2,1),('{db3a0248-b020-4cb9-8e3e-57f673183af1}',3,2,1),('{f1ad3fd3-8225-4cfa-9648-bca297a8ccec}',1,2,3),('{f7a41b08-5868-4e51-8fb5-306a8ffd497d}',1,2,3);
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
INSERT INTO `Users` VALUES ('{49fffec7-48e4-4bbf-83b8-ee85e97051c5}','test4@mail.ru','testname','test','',0,'12345','STANDART_USER',0,'2020-02-12 10:07:33','2020-02-12 10:07:33'),('{574e9d57-24fa-4a65-b1dd-ff7b742d18f2}','igor.ge@mail.ru','Igor (TEST USER)','Grebenev','Quantumsoft',0,'m1llions','STANDART_USER',0,'2020-01-30 10:15:46','2020-01-30 10:15:46'),('{57a98e8e-f5ab-4032-b647-b793b60468ff}','medalynx@gmail.com','Admin','','',0,'admin','ADMIN',0,'2020-02-05 01:57:22','2020-02-05 01:57:22'),('{756f72f3-5150-4e85-b02a-a3f0ab23e07e}','test3@mail.ru','super','user','test',0,'12345','STANDART_USER',0,'2020-02-12 10:01:21','2020-02-12 10:01:21'),('{b3643e06-bd3a-4429-aacb-89a52f8f7950}','antony@mail.ru','antony','antony','antony corporation',0,'12345','STANDART_USER',0,'2020-02-10 06:02:57','2020-02-10 06:02:57'),('{bde09723-429a-4d20-a0e1-ab1672936243}','test1@mail.ru','antony','antony','antony',0,'12345','STANDART_USER',0,'2020-02-12 09:59:01','2020-02-12 09:59:01'),('{e8d62dd6-59d4-4029-a1b1-248da6f933e4}','test@mail.ru','test','test','adf',0,'12345678Ab!','STANDART_USER',0,'2020-02-14 07:48:51','2020-02-14 07:48:51'),('{f62a2c71-77db-4166-bad8-5ff2676ac21b}','test2@mail.ru','user','test','test',0,'12345','STANDART_USER',0,'2020-02-12 10:00:16','2020-02-12 10:00:16');
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

-- Dump completed on 2020-02-14 17:20:17
