/*
SQLyog Community v9.02 
MySQL - 5.1.35-community : Database - squarekart
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`squarekart` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `squarekart`;

/*Table structure for table `agent_map` */

DROP TABLE IF EXISTS `agent_map`;

CREATE TABLE `agent_map` (
  `called_number` varchar(500) DEFAULT NULL,
  `agentlist` varchar(500) DEFAULT NULL,
  `id` int(11) NOT NULL AUTO_INCREMENT,
  UNIQUE KEY `id` (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=3 DEFAULT CHARSET=latin1;

/*Data for the table `agent_map` */

LOCK TABLES `agent_map` WRITE;

insert  into `agent_map`(`called_number`,`agentlist`,`id`) values ('1800232133','dffsdf',1),('180023213','trtret',2);

UNLOCK TABLES;

/*Table structure for table `child` */

DROP TABLE IF EXISTS `child`;

CREATE TABLE `child` (
  `child` varchar(50) DEFAULT NULL,
  `tname` varchar(50) DEFAULT NULL,
  `tmob` varchar(50) DEFAULT NULL,
  `tschool` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `child` */

LOCK TABLES `child` WRITE;

UNLOCK TABLES;

/*Table structure for table `customer` */

DROP TABLE IF EXISTS `customer`;

CREATE TABLE `customer` (
  `uname` varchar(50) DEFAULT NULL,
  `mobile_no` varchar(20) DEFAULT NULL,
  `alternate_no` varchar(20) DEFAULT NULL,
  `email` varchar(50) DEFAULT NULL,
  `dob` varchar(50) DEFAULT NULL,
  `gender` varchar(20) DEFAULT NULL,
  `marital` varchar(20) DEFAULT NULL,
  `spouse_name` varchar(50) DEFAULT NULL,
  `spouse_mobile` varchar(20) DEFAULT NULL,
  `spouse_alternate` varchar(20) DEFAULT NULL,
  `spouse_dob` varchar(50) DEFAULT NULL,
  `resident_add` varchar(500) DEFAULT NULL,
  `official_add` varchar(50) DEFAULT NULL,
  `car` varchar(20) DEFAULT NULL,
  `car_brand` varchar(50) DEFAULT NULL,
  `car_no` varchar(20) DEFAULT NULL,
  `f_name` varchar(50) DEFAULT NULL,
  `f_mobile` varchar(20) DEFAULT NULL,
  `f_dob` varchar(50) DEFAULT NULL,
  `m_name` varchar(50) DEFAULT NULL,
  `m_mobile` varchar(20) DEFAULT NULL,
  `m_dob` varchar(50) DEFAULT NULL,
  `b_name` varchar(50) DEFAULT NULL,
  `b_mobile` varchar(20) DEFAULT NULL,
  `b_dob` varchar(50) DEFAULT NULL,
  `s_name` varchar(50) DEFAULT NULL,
  `s_mobile` varchar(20) DEFAULT NULL,
  `s_dob` varchar(50) DEFAULT NULL,
  `credit_card_no` varchar(50) DEFAULT NULL,
  `delivery_add` varchar(500) DEFAULT NULL,
  `aniversary` varchar(50) DEFAULT NULL,
  `child` varchar(10) DEFAULT NULL,
  `c_name1` varchar(50) DEFAULT NULL,
  `c_mobile1` varchar(20) DEFAULT NULL,
  `c_school1` varchar(100) DEFAULT NULL,
  `c_name2` varchar(50) DEFAULT NULL,
  `c_mobile2` varchar(20) DEFAULT NULL,
  `c_school2` varchar(100) DEFAULT NULL,
  `c_name3` varchar(50) DEFAULT NULL,
  `c_mobile3` varchar(20) DEFAULT NULL,
  `c_school3` varchar(100) DEFAULT NULL,
  `c_name4` varchar(50) DEFAULT NULL,
  `c_mobile4` varchar(20) DEFAULT NULL,
  `c_school4` varchar(100) DEFAULT NULL,
  `c_name5` varchar(50) DEFAULT NULL,
  `c_mobile5` varchar(20) DEFAULT NULL,
  `c_school5` varchar(100) DEFAULT NULL,
  `dat` varchar(50) DEFAULT NULL,
  `ticket_id` varchar(50) DEFAULT NULL,
  `tname` varchar(50) DEFAULT NULL,
  `tmob` varchar(50) DEFAULT NULL,
  `tschool` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `customer` */

LOCK TABLES `customer` WRITE;

insert  into `customer`(`uname`,`mobile_no`,`alternate_no`,`email`,`dob`,`gender`,`marital`,`spouse_name`,`spouse_mobile`,`spouse_alternate`,`spouse_dob`,`resident_add`,`official_add`,`car`,`car_brand`,`car_no`,`f_name`,`f_mobile`,`f_dob`,`m_name`,`m_mobile`,`m_dob`,`b_name`,`b_mobile`,`b_dob`,`s_name`,`s_mobile`,`s_dob`,`credit_card_no`,`delivery_add`,`aniversary`,`child`,`c_name1`,`c_mobile1`,`c_school1`,`c_name2`,`c_mobile2`,`c_school2`,`c_name3`,`c_mobile3`,`c_school3`,`c_name4`,`c_mobile4`,`c_school4`,`c_name5`,`c_mobile5`,`c_school5`,`dat`,`ticket_id`,`tname`,`tmob`,`tschool`) values ('arya singh','9999999999','7867867867','samidrawat@gmail.com','2014-11-04','Female','Married','rwerwe','9999999999','9999999999','','wqedqwewq','','','','','hjgjhghj','','','er','','','','','','','','','','wqedqwewq','','--Select--','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','2014-11-13 11:34:16 PM','6529945349',NULL,NULL,NULL),('Raj sharma','7666666666','7555555555','samidrawat@gmail.com','2014-11-20','Female','Married','rwerwe','','8675675675','','wqedqwewq','','','','','hjgjhghj','7564353453','','er','','','','','','','','','','wqedqwewq','','--Select--','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','2014-11-13 11:57:40 PM','3989632133',NULL,NULL,NULL),('sid jain','9868586662','9868586662','samidrawat@gmail.com','2014-11-12','Male','Unmarried','sid rani','9868586662','','2014-11-19','gaziabad','','Yes','','','abc','','','xyz','','','','','','','','','4444','gaziabad','','--Select--','0','0','0','0','0','0','0','0','0','0','0','0','0','0','0','2014-11-14 2:03:37 AM','6442172665',NULL,NULL,NULL);

UNLOCK TABLES;

/*Table structure for table `newcall` */

DROP TABLE IF EXISTS `newcall`;

CREATE TABLE `newcall` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `mobileno` varchar(15) DEFAULT NULL,
  `agentid` varchar(30) DEFAULT NULL,
  `trndate` varchar(30) DEFAULT NULL,
  `status` varchar(15) DEFAULT NULL,
  `call_id` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `newcall` */

LOCK TABLES `newcall` WRITE;

UNLOCK TABLES;

/*Table structure for table `oldcalls` */

DROP TABLE IF EXISTS `oldcalls`;

CREATE TABLE `oldcalls` (
  `id` int(11) NOT NULL DEFAULT '0',
  `mobileno` varchar(15) DEFAULT NULL,
  `agentid` varchar(30) DEFAULT NULL,
  `trndate` varchar(30) DEFAULT NULL,
  `status` varchar(15) DEFAULT NULL,
  `call_id` varchar(100) DEFAULT NULL
) ENGINE=MyISAM DEFAULT CHARSET=utf8;

/*Data for the table `oldcalls` */

LOCK TABLES `oldcalls` WRITE;

insert  into `oldcalls`(`id`,`mobileno`,`agentid`,`trndate`,`status`,`call_id`) values (1,'9911156262','AG001','2014-11-13 03:41:52','Accept','123'),(3,'909099999','ag001','2014-11-13 8:51:21 PM','Accept','945678999'),(4,'999999999','ag001','2014-11-13 8:51:49 PM','Accept','945678999'),(5,'9999999999','ag001','2014-11-13 8:52:19 PM','Accept','945678999'),(6,'9999999999','ag001','2014-11-13 8:52:30 PM','Busy','945678999'),(7,'9999999999','ag003','2014-11-13 8:55:05 PM','Busy','945678999'),(9,'9999999999','ag001','2014-11-13 8:57:15 PM','Accept','945678999'),(8,'9999999999','ag001','2014-11-13 8:56:02 PM','Busy','945678999'),(10,'9990099999','ag001','2014-11-13 9:05:36 PM','Busy','945678999'),(11,'9990099999','ag001','2014-11-13 9:08:39 PM','Accept','945678999'),(12,'9999999999','ag001','2014-11-13 9:08:53 PM','Accept','945678999'),(13,'9999999999','ag001','2014-11-13 9:11:23 PM','Accept','945678999'),(14,'9999999999','ag001','2014-11-13 9:12:15 PM','Accept','945678999'),(15,'9999999999','ag001','2014-11-13 9:14:05 PM','Accept','945678999'),(16,'9999999999','ag001','2014-11-13 9:18:35 PM','Accept','945678999'),(17,'7867867867','ag001','2014-11-13 9:18:53 PM','Accept','945678999'),(18,'7867867867','ag001','2014-11-13 9:19:20 PM','Accept','945678999'),(19,'7867867867','ag001','2014-11-13 9:21:36 PM','Accept','945678999'),(20,'7867867867','ag001','2014-11-13 10:18:23 PM','Accept','945678999'),(21,'8888888888','ag001','2014-11-13 10:19:46 PM','Busy','945678999'),(22,'8888888888','ag001','2014-11-13 11:31:31 PM','Accept','945678999'),(23,'8888989899','ag001','2014-11-13 11:32:18 PM','Accept','945678999'),(24,'8888888888','ag001','2014-11-13 11:33:15 PM','Accept','945678999'),(25,'8888888888','ag001','2014-11-13 11:36:57 PM','Accept','945678999'),(26,'8888888888','ag001','2014-11-13 11:38:09 PM','Accept','945678999'),(27,'8888888888','ag001','2014-11-13 11:39:04 PM','Accept','945678999'),(28,'8888888888','ag001','2014-11-13 11:41:19 PM','Accept','945678999'),(29,'8888888888','ag001','2014-11-13 11:42:05 PM','Accept','945678999'),(30,'8888888888','ag001','2014-11-13 11:44:43 PM','Accept','945678999'),(31,'8888888888','ag001','2014-11-13 11:49:25 PM','Accept','945678999'),(32,'8888888888','ag001','2014-11-14 12:04:08 AM','Accept','945678999'),(33,'8888888888','ag001','2014-11-14 12:05:22 AM','Accept','945678999'),(34,'9999999999','ag001','2014-11-14 12:07:13 AM','Accept','945678999'),(2,'909099999','ag002','2014-11-13 8:42:10 PM','Accept','945678999'),(3,'9949494949','ag002','2014-11-14 3:00:07 AM','Accept','32423423'),(4,'9949494949','ag001','2014-11-14 4:48:27 AM','Accept','32423423'),(5,'9999999999','ag001','2014-11-14 4:49:08 AM','Accept','32423423');

UNLOCK TABLES;

/*Table structure for table `squarekart_ui_agent` */

DROP TABLE IF EXISTS `squarekart_ui_agent`;

CREATE TABLE `squarekart_ui_agent` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `UserID` varchar(30) DEFAULT NULL,
  `Password` varchar(30) DEFAULT NULL,
  `last_login` varchar(30) DEFAULT NULL,
  `status` varchar(10) DEFAULT NULL,
  `role` varchar(10) DEFAULT NULL,
  `is_active` varchar(1) DEFAULT NULL,
  `agent_number` varchar(20) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB AUTO_INCREMENT=5 DEFAULT CHARSET=latin1;

/*Data for the table `squarekart_ui_agent` */

LOCK TABLES `squarekart_ui_agent` WRITE;

insert  into `squarekart_ui_agent`(`id`,`UserID`,`Password`,`last_login`,`status`,`role`,`is_active`,`agent_number`) values (1,'AG001','ag001','11/24/14 11:24:19 PM','FREE','AGENT','1','912345789'),(2,'AG002','ag002','2014-11-14 3:00:30 AM','FREE','AGENT','0','923456777'),(3,'AG003','ag003','2014-11-13 10:25:57 PM','FREE','AGENT','1','945678999'),(4,'ADMIN','admin123','11/24/14 11:34:31 PM','FREE','ADMIN','1',NULL);

UNLOCK TABLES;

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
