-- MySQL dump 10.13  Distrib 8.0.19, for Win64 (x86_64)
--
-- Host: localhost    Database: enregistement
-- ------------------------------------------------------
-- Server version	8.0.19

/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!50503 SET NAMES utf8 */;
/*!40103 SET @OLD_TIME_ZONE=@@TIME_ZONE */;
/*!40103 SET TIME_ZONE='+00:00' */;
/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;

--
-- Table structure for table `users`
--

DROP TABLE IF EXISTS `users`;
/*!40101 SET @saved_cs_client     = @@character_set_client */;
/*!50503 SET character_set_client = utf8mb4 */;
CREATE TABLE `users` (
  `user_id` int NOT NULL AUTO_INCREMENT,
  `username` varchar(100) DEFAULT NULL,
  `password` varchar(100) DEFAULT NULL,
  `first_name` varchar(100) DEFAULT NULL,
  `last_name` varchar(100) DEFAULT NULL,
  `address` text,
  `email` varchar(150) DEFAULT NULL,
  PRIMARY KEY (`user_id`)
) ENGINE=InnoDB AUTO_INCREMENT=21 DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_0900_ai_ci;
/*!40101 SET character_set_client = @saved_cs_client */;

--
-- Dumping data for table `users`
--

LOCK TABLES `users` WRITE;
/*!40000 ALTER TABLE `users` DISABLE KEYS */;
INSERT INTO `users` VALUES (1,'user','pass','camara','bafode','sakarya','mamd'),(2,'alp','fkdfjf','alpha','diallo','sangared',NULL),(4,'hkll','fkfjj','dkfkfk','fjfjgjh','tghjkkj','tyuı'),(5,'djsu','123','als','dkkfj',NULL,'dkkf'),(7,'alpho1','123','ALPHA','CONDE','','al@gmail.com'),(8,'baldeee','1245','thierno','balde','Dislf','thb@gmail.com'),(9,'user','12','adksl','gld',NULL,'fjjffj'),(10,'mhmt','123','djfjgk','gkfkfk',NULL,'jjffmgmg'),(11,'admin','admin','Bafode','Camara',NULL,'bafodecamara1996@gmail.com'),(12,'admin1','1234','bafode','camara',NULL,'bafodecamara1998@gmail.com'),(13,'osman','0000','ousmane','diallo',NULL,'oc@gmail.com'),(14,'yaya','0000','sekou','yaya',NULL,'yaya@gmail.com'),(15,'biya','0000','biya','Diallo',NULL,'Conakry'),(16,'fgg','00','baf','dd',NULL,'fff'),(17,'superuser','000','bafode','camara',NULL,'bafode@gmail.com'),(18,'thrno','123','Thierno','Balde',NULL,'Saka'),(19,'bald1','1245','thierno','balde',NULL,'thb@gmail.com'),(20,'arsen','120','Arsen','Adeby',NULL,'arsen@gmail.com');
/*!40000 ALTER TABLE `users` ENABLE KEYS */;
UNLOCK TABLES;
/*!40103 SET TIME_ZONE=@OLD_TIME_ZONE */;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;

-- Dump completed on 2020-05-10 17:49:23
