/*
SQLyog Community v9.02 
MySQL - 5.1.35-community : Database - bg_motors
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`bg_motors` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `bg_motors`;

/*Table structure for table `branch_details` */

DROP TABLE IF EXISTS `branch_details`;

CREATE TABLE `branch_details` (
  `location` varchar(100) DEFAULT NULL,
  `sales` varchar(100) DEFAULT NULL,
  `sales_no` varchar(20) DEFAULT NULL,
  `service` varchar(100) DEFAULT NULL,
  `service_no` varchar(20) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `branch_details` */

insert  into `branch_details`(`location`,`sales`,`sales_no`,`service`,`service_no`) values ('Amritsar','fordsalesasr@bhagatgroup.com','9876020970','fordserasr@bhagatgroup.com','9876020975'),('Bathinda','fordsalesbat@bhagatgroup.com','9876020960','fordserbat@bhagatgroup.com','9876020965'),('Chandigarh','fordsaleschd@bhagatgroup.com','9876020933','fordserchd@bhagatgroup.com','9915030288'),('Dehradun','fordsalesdoon@bhagatgroup.com','9897893400','fordsevdoon@bhagatgroup.com','9897893407'),('Jalandhar','fordsalesjal@bhagatgroup.com','9876020930','fordserjal@bhagatgroup.com','9915030299'),('Ludhiana','fordsaleslud@bhagatgroup.com','9876020910','fordserldh@bhagatgroup.com','9876503195'),('Patiala','fordsalespat@bhagatgroup.com','9876020950','fordserpat@bhagatgroup.com','9876020955'),('Sangrur','fordsalessan@bhagatgroup.com','9876021020','fordsersan@bhagatgroup.com','9876021066'),('Pathankot','fordsalespkt@bhagatgroup.com','9876005700','fordserpkt@bhagatgroup.com','9876021038'),('Moga','fordsalesmoga@bhagatgroup.com','8288097070','fordsermoga@bhagatgroup.com','9876051078'),('Nawasher','fordsalesnsr@bhagatgroup.com','9501127744','fordsernsr@bhagatgroup.com','9815503083'),('Panchkula','fordsalespkl@bhagatgroup.com','9876300209','fordserpkl@bhagatgroup.com','9876503193');

/*Table structure for table `call_log` */

DROP TABLE IF EXISTS `call_log`;

CREATE TABLE `call_log` (
  `id` varchar(50) DEFAULT NULL,
  `date` varchar(50) DEFAULT NULL,
  `time` varchar(50) DEFAULT NULL,
  `called_number` varchar(50) DEFAULT NULL,
  `caller_number` varchar(50) DEFAULT NULL,
  `caller_status` varchar(100) DEFAULT NULL,
  `caller_duration` varchar(50) DEFAULT NULL,
  `call_forwarding_number` varchar(50) DEFAULT NULL,
  `call_connected_to` varchar(50) DEFAULT NULL,
  `call_transfer_status` varchar(100) DEFAULT NULL,
  `call_status` varchar(100) DEFAULT NULL,
  `call_transfer_duration` varchar(50) DEFAULT NULL,
  `key_pressed` varchar(50) DEFAULT NULL,
  `call_recordingurl` varchar(400) DEFAULT NULL,
  `call_uuid` varchar(400) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `call_log` */

/*Table structure for table `login` */

DROP TABLE IF EXISTS `login`;

CREATE TABLE `login` (
  `user_id` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL,
  `role` varchar(50) DEFAULT NULL,
  `status` varchar(20) DEFAULT NULL,
  `is_active` varchar(10) DEFAULT NULL,
  `last_login_time` varchar(50) NOT NULL DEFAULT 'now()'
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `login` */

insert  into `login`(`user_id`,`password`,`role`,`status`,`is_active`,`last_login_time`) values ('admin','admin','admin','Free','1','2015-01-06'),('ag001','ag001','sale','Free','1','2015-01-07'),('ag002','ag002','service','Free','1','2015-01-07'),('ag003','ag003','sale','Free','1','2014-12-18');

/*Table structure for table `newcall` */

DROP TABLE IF EXISTS `newcall`;

CREATE TABLE `newcall` (
  `id` int(11) NOT NULL AUTO_INCREMENT,
  `mobile` varchar(20) DEFAULT NULL,
  `ext` varchar(20) DEFAULT NULL,
  `agent_id` varchar(50) DEFAULT NULL,
  `status` varchar(20) DEFAULT NULL,
  `trans_date` varchar(50) DEFAULT NULL,
  `call_id` varchar(50) DEFAULT NULL,
  PRIMARY KEY (`id`)
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `newcall` */

/*Table structure for table `oldcalls` */

DROP TABLE IF EXISTS `oldcalls`;

CREATE TABLE `oldcalls` (
  `id` varchar(20) DEFAULT NULL,
  `mobile` varchar(20) DEFAULT NULL,
  `ext` varchar(20) DEFAULT NULL,
  `agent_id` varchar(50) DEFAULT NULL,
  `status` varchar(20) DEFAULT NULL,
  `trans_date` varchar(50) DEFAULT NULL,
  `call_id` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `oldcalls` */

insert  into `oldcalls`(`id`,`mobile`,`ext`,`agent_id`,`status`,`trans_date`,`call_id`) values ('1','9999999999','1','ag001','Accept','2014-12-16','9999'),('2','9999999999','1','ag001','Busy','2014-12-16','9999'),('3','9999999999','1','ag001','Not Response','2014-12-16','9999'),('4','9999999999','1','ag001','Accept','2014-12-16','9999'),('5','9999999999','1','ag001','Not Response','2014-12-16','9999'),('6','9999999999','1','ag001','Busy','2014-12-16','9999'),('7','9999999999','1','ag001','Not Response','2014-12-16','9999'),('8','9999999999','1','ag001','Not Response','2014-12-16','9999'),('9','9999999999','1','ag001','Not Response','2014-12-16','9999'),('10','9999999999','2','ag001','Not Response','2014-12-16','9999'),('11','9999999999','2','ag001','Not Response','2014-12-16','9999'),('12','9999999999','1','ag001','Not Response','2014-12-16','9999'),('13','9999999999','1','ag001','Accept','2014-12-16','9999'),('14','9999999999','1','ag001','Accept','2014-12-16','9999'),('15','9999999999','2','ag001','Accept','2014-12-16','9999'),('16','9999999999','2','ag001','Accept','2014-12-16','9999'),('17','9999999999','1','ag001','Accept','2014-12-16','9999'),('18','9999999999','2','ag001','Accept','2014-12-16','9999'),('19','9999999999','2','ag001','Accept','2014-12-16','9999'),('20','9999999999','2','ag001','Accept','2014-12-16','9999'),('21','9999999999','2','ag001','Accept','2014-12-16','9999'),('22','9999999999','1','ag001','Accept','2014-12-16','9999'),('23','9999999999','2','ag001','Accept','2014-12-16','9999'),('24','9999999999','1','ag001','Accept','2014-12-17','9999'),('25','9999999999','1','ag001','Not Response','2014-12-17','9999'),('26','9999999999','1','ag001','Not Response','2014-12-17','9999'),('27','9999999999','1','ag001','Accept','2014-12-17','9999'),('28','9999999999','1','ag001','Busy','2014-12-17','9999'),('29','9999999999','1','ag001','Accept','2014-12-17','9999'),('30','9999999999','1','ag001','Accept','2014-12-17','9999'),('31','9999999999','1','ag001','Accept','2014-12-17','9999'),('32','9999999999','1','ag001','Accept','2014-12-17','9999'),('33','9999999999','1','ag001','Accept','2014-12-17','9999'),('34','9999999999','1','ag001','Accept','2014-12-17','9999'),('35','9999999999','1','ag001','Accept','2014-12-17','9999'),('36','9999999999','1','ag001','Accept','2014-12-17','9999'),('37','9999999999','1','ag001','Accept','2014-12-17','9999'),('38','9900000000','1','ag001','Accept','2014-12-17','9999'),('39','9900000000','1','ag001','Accept','2014-12-17','9999'),('40','9900000000','1','ag001','Accept','2014-12-17','9999'),('41','9900000000','1','ag001','Accept','2014-12-17','9999'),('43','9900000000','1','ag002','Accept','2014-12-17','9999'),('42','9900000000','1','ag001','Accept','2014-12-17','9999'),('1','9678678678','1','ag001','Accept','2014-12-17','9999'),('2','9999999999','1','ag001','Accept','2014-12-17','9999'),('3','9999999999','1','ag001','Accept','2014-12-17','9999'),('4','9999999999','1','ag001','Not Response','2014-12-17','9999'),('5','9999999999','1','ag001','Not Response','2014-12-17','9999'),('6','9999999999','1','ag001','Busy','2014-12-17','9999'),('7','8285595074','1','ag001','Busy','2014-12-17','9999'),('8','8285595074','1','ag001','Accept','2014-12-17','9999'),('9','9999999999','1','ag001','Not Response','2014-12-17','9999'),('10','9999999999','1','ag001','Accept','2014-12-17','9999'),('11','9999999999','1','ag001','Accept','2014-12-17','9999'),('12','9999999999','1','ag001','Not Response','2014-12-17','9999'),('13','9999999999','1','ag001','Not Response','2014-12-17','9999'),('14','9999999999','1','ag001','Not Response','2014-12-17','9999'),('15','9999999999','1','ag001','Accept','2014-12-17','9999'),('16','9999999999','1','ag001','Busy','2014-12-17','9999'),('17','9999999999','1','ag001','Accept','2014-12-17','9999'),('19','9999999999','1','ag001','Accept','2014-12-17','9999'),('20','9999999999','1','ag001','Accept','2014-12-17','9999'),('18','9999999999','2','ag002','Busy','2014-12-17','9999'),('21','9999999999','2','ag002','Accept','2014-12-17','9999'),('22','9999999999','2','ag002','Busy','2014-12-17','9999'),('24','9999999999','1','ag001','Accept','2014-12-17','9999'),('25','9999999999','1','ag001','Accept','2014-12-17','9999'),('23','9999999999','2','ag002','Not Response','2014-12-17','9999'),('26','9999999999','2','ag002','Accept','2014-12-17','9999'),('27','9999999999','2','ag002','Busy','2014-12-17','9999'),('28','9999999999','2','ag002','Not Response','2014-12-17','9999'),('29','9999999999','2','ag002','Accept','2014-12-17','9999'),('30','9999999999','2','ag002','Not Response','2014-12-17','9999'),('31','9999999999','2','ag002','Accept','2014-12-17','9999'),('32','9999999999','2','ag002','Accept','2014-12-17','9999'),('33','9999999999','2','ag002','Accept','2014-12-17','9999'),('34','9999999999','2','ag002','Accept','2014-12-17','9999'),('35','9999999999','2','ag002','Accept','2014-12-17','9999'),('36','9999999999','2','ag002','Accept','2014-12-17','9999'),('37','9999999999','2','ag002','Accept','2014-12-17','9999'),('38','9999999999','2','ag002','Accept','2014-12-17','9999'),('39','9999978777','2','ag002','Accept','2014-12-17','9999'),('40','9999999999','2','ag002','Accept','2014-12-17','9999'),('41','9999999999','2','ag002','Accept','2014-12-17','9999'),('42','9999999999','1','ag001','Accept','2014-12-17','9999'),('43','9999999999','1','ag001','Accept','2014-12-17','9999'),('44','9999999999','1','ag001','Accept','2014-12-17','9999'),('45','9678678678','1','ag001','Accept','2014-12-18','9999'),('46','9678678678','1','ag003','Accept','2014-12-18','9999'),('47','9678678678','1','ag003','Not Response','2014-12-18','9999'),('48','9678678678','1','ag003','Not Response','2014-12-18','9999'),('49','9678678678','1','ag003','Not Response','2014-12-18','9999'),('50','9678678678','1','ag003','Busy','2014-12-18','9999'),('51','9678678678','1','ag003','Not Response','2014-12-18','9999'),('52','9678678678','1','ag003','Busy','2014-12-18','9999'),('53','9678678678','1','ag001','Accept','2014-12-18','9999'),('54','9678678678','1','ag001','Busy','2014-12-18','9999'),('55','9678678678','1','ag001','Accept','2014-12-18','9999'),('56','9999999999','1','ag001','Accept','2014-12-18','9999'),('57','9999999999','1','ag001','Accept','2014-12-18','9999'),('58','9999999999','1','ag001','Accept','2014-12-18','9999'),('59','9999999999','1','ag001','Accept','2014-12-18','9999'),('60','9999999999','1','ag001','Accept','2014-12-18','9999'),('61','9999999999','1','ag001','Accept','2014-12-18','9999'),('62','9999999999','1','ag001','Busy','2014-12-18','9999'),('63','9999999999','1','ag001','Accept','2014-12-18','9999'),('64','9999999999','1','ag001','Not Response','2014-12-18','9999'),('65','9999999999','1','ag001','Accept','2014-12-18','9999'),('66','9999999999','1','ag001','Accept','2014-12-18','9999'),('67','9999999999','1','ag001','Accept','2014-12-18','9999'),('68','9999999999','1','ag001','Not Response','2014-12-18','9999'),('69','9999999999','1','ag001','Not Response','2014-12-18','9999'),('70','9999999999','1','ag001','Accept','2014-12-18','9999'),('71','9999999999','1','ag001','Busy','2014-12-18','9999'),('72','9000000000','1','ag001','Busy','2014-12-18','9999'),('73','9000000000','1','ag001','Accept','2014-12-18','9999'),('74','9000000000','1','ag001','Accept','2014-12-18','9999'),('75','9000000000','1','ag001','Accept','2014-12-18','9999'),('76','9000000000','1','ag001','Accept','2014-12-18','9999'),('77','9000000000','1','ag001','Accept','2014-12-18','9999'),('78','9000000000','1','ag001','Busy','2014-12-18','9999'),('79','9999999000','1','ag001','Busy','2014-12-18','9999'),('80','9000000000','1','ag001','Busy','2014-12-18','9999'),('81','9088888000','1','ag001','Busy','2014-12-18','9999'),('82','9000008000','1','ag001','Accept','2014-12-18','9999'),('83','9000008000','1','ag001','Accept','2014-12-18','9999'),('84','9000008000','1','ag001','Accept','2014-12-18','9999'),('85','90000000','1','ag001','Busy','2014-12-18','9999'),('86','9000000000','1','ag001','Accept','2014-12-18','9999'),('87','9777777777','1','ag001','Accept','2014-12-18','9999'),('88','9777777777','1','ag001','Accept','2014-12-18','9999'),('89','9777777777','1','ag001','Accept','2014-12-18','9999'),('91','9777777777','2','ag002','Accept','2014-12-18','9999'),('92','9000000000','2','ag002','Accept','2014-12-18','9999'),('93','9000000000','2','ag002','Accept','2014-12-18','9999'),('94','9000000000','1','ag003','Accept','2014-12-18','9999'),('95','9777777777','1','ag003','Accept','2014-12-18','9999'),('96','9777777777','1','ag003','Accept','2014-12-18','9999'),('97','9777777777','1','ag003','Not Response','2014-12-18','9999'),('98','9775555557','1','ag003','Accept','2014-12-18','9999'),('99','9775555557','1','ag003','Accept','2014-12-18','9999'),('100','9775555557','2','ag002','Accept','2014-12-18','9999'),('90','9777777777','1','ag001','Accept','2014-12-18','9999'),('102','9775555557','1','ag001','Accept','2014-12-18','9999'),('103','9775555557','1','ag001','Accept','2014-12-18','9999'),('104','9775555557','1','ag001','Accept','2014-12-18','9999'),('105','9775555557','1','ag001','Not Response','2014-12-18','9999'),('106','9775555557','1','ag001','Accept','2014-12-18','9999'),('107','9775555557','1','ag001','Accept','2014-12-18','9999'),('108','9775555557','1','ag001','Accept','2014-12-18','9999'),('109','9775555557','1','ag001','Accept','2014-12-18','9999'),('110','9775555557','1','ag001','Busy','2014-12-18','9999'),('101','9775555557','2','ag002','Accept','2014-12-18','9999'),('111','9775555557','1','ag001','Busy','2014-12-18','9999'),('112','9775555557','1','ag001','Accept','2014-12-18','9999'),('113','9775555557','1','ag001','Busy','2014-12-18','9999'),('114','9999999999','1','ag001','Accept','2014-12-19','9999'),('115','9999999999','1','ag001','Accept','2014-12-19','9999'),('116','9999999999','1','ag001','Busy','2014-12-19','9999'),('1','9999999999','1','Ag001','Accept','2015-01-06','121212'),('2','9999999999','2','Ag002','Accept','2015-01-06','121212'),('3','9999999999','2','Ag002','Accept','2015-01-06','121212'),('4','9999999900','2','Ag002','Accept','2015-01-06','121212'),('5','9999999900','2','Ag002','Accept','2015-01-06','121212'),('6','9999999900','2','Ag002','Accept','2015-01-06','121212'),('7','9999999900','2','Ag002','Busy','2015-01-06','121212'),('1','9999999999','1','Ag001','Busy','2015-01-07','121212'),('2','9999998888','1','Ag001','Accept','2015-01-07','121212'),('3','9999998888','1','Ag001','Accept','2015-01-07','121212'),('4','9999999999','1','Ag001','Busy','2015-01-07','121212'),('5','9999998888','1','Ag001','Busy','2015-01-07','121212'),('6','9999998888','1','Ag001','Busy','2015-01-07','121212'),('7','9999999999','1','Ag001','Not Response','2015-01-07','121212'),('8','9999998888','1','Ag001','Not Response','2015-01-07','121212'),('9','9999999999','1','Ag001','Not Response','2015-01-07','121212'),('10','9999998888','1','Ag001','Not Response','2015-01-07','121212'),('11','9999999999','1','Ag001','Not Response','2015-01-07','121212'),('12','9999998888','1','Ag001','Busy','2015-01-07','121212'),('13','9999998888','1','Ag001','Busy','2015-01-07','121212'),('14','9999998888','1','Ag001','Not Response','2015-01-07','121212'),('15','9999998888','1','Ag001','Accept','2015-01-07','121212'),('16','9999999999','1','Ag001','Not Response','2015-01-07','121212'),('17','9999998888','1','Ag001','Busy','2015-01-07','121212'),('18','9999998888','1','Ag001','Not Response','2015-01-07','121212'),('19','9999999999','1','Ag001','Not Response','2015-01-07','121212'),('20','9999998888','1','Ag001','Busy','2015-01-07','121212'),('21','9999998888','1','Ag001','Busy','2015-01-07','121212'),('22','9999999999','1','Ag001','Not Response','2015-01-07','121212'),('23','9999998888','1','Ag001','Not Response','2015-01-07','121212'),('24','9999999999','1','Ag001','Not Response','2015-01-07','121212'),('25',' 099999999999','1','Ag001','Accept','2015-01-07','121212'),('26','+99999999999','1','Ag001','Accept','2015-01-07','121212'),('27','+99999999999','1','Ag001','Accept','2015-01-07','121212'),('28','+009999999999','1','Ag001','Accept','2015-01-07','121212'),('29','+009999999999','1','Ag001','Accept','2015-01-07','121212');

/*Table structure for table `sale_service` */

DROP TABLE IF EXISTS `sale_service`;

CREATE TABLE `sale_service` (
  `ticket` int(11) NOT NULL AUTO_INCREMENT,
  `executive_id` varchar(50) DEFAULT NULL,
  `name` varchar(50) DEFAULT NULL,
  `alternate_no` varchar(50) DEFAULT NULL,
  `alternate_no2` varchar(50) DEFAULT NULL,
  `email` varchar(100) DEFAULT NULL,
  `profession` varchar(100) DEFAULT NULL,
  `location` varchar(50) DEFAULT NULL,
  `customer_loc` varchar(50) DEFAULT NULL,
  `source` varchar(100) DEFAULT NULL,
  `model_interest` varchar(50) DEFAULT NULL,
  `diesel_petrol` varchar(50) DEFAULT NULL,
  `test_drive` varchar(50) DEFAULT NULL,
  `current_vehicle_info` varchar(200) DEFAULT NULL,
  `interest_in_exchange` varchar(50) DEFAULT NULL,
  `previous_remark` varchar(1000) DEFAULT NULL,
  `remark` varchar(500) DEFAULT NULL,
  `car_model` varchar(50) DEFAULT NULL,
  `model_year` varchar(50) DEFAULT NULL,
  `km_done` varchar(50) DEFAULT NULL,
  `prefer_date_time` varchar(50) DEFAULT NULL,
  `required_pickup` varchar(50) DEFAULT NULL,
  `date_of_entry` varchar(50) DEFAULT 'now()',
  `update_date` varchar(50) DEFAULT 'now()',
  `role` varchar(50) DEFAULT NULL,
  `callid` varchar(50) DEFAULT NULL,
  `sms` varchar(100) DEFAULT NULL,
  PRIMARY KEY (`ticket`)
) ENGINE=InnoDB AUTO_INCREMENT=10006 DEFAULT CHARSET=latin1;

/*Data for the table `sale_service` */

insert  into `sale_service`(`ticket`,`executive_id`,`name`,`alternate_no`,`alternate_no2`,`email`,`profession`,`location`,`customer_loc`,`source`,`model_interest`,`diesel_petrol`,`test_drive`,`current_vehicle_info`,`interest_in_exchange`,`previous_remark`,`remark`,`car_model`,`model_year`,`km_done`,`prefer_date_time`,`required_pickup`,`date_of_entry`,`update_date`,`role`,`callid`,`sms`) values (10001,'ag001','harish','+919999999999','','samidrawat@gmail.com','hr','Dehradun',NULL,'','2011','Diesel','Yes','','',NULL,'testing.....',NULL,NULL,NULL,NULL,NULL,'2015-01-06','2015-01-07','sale','20152506012503032_9999999999',NULL),(10002,'ag001','harish','9999999999','','samidrawat@gmail.com','hr','Dehradun',NULL,'','2011','Diesel','Yes','','',NULL,'testing.....',NULL,NULL,NULL,NULL,NULL,'2015-01-06','now()','sale','20152706012745096_9999999999',NULL),(10003,'ag002','harish','+919999999900','','samidrawat@gmail.com',NULL,'Dehradun',NULL,'',NULL,'',NULL,NULL,NULL,'testing','testing2','df','1111','1111111111',' 00','','2015-01-06','2015-01-07','service','20153006013054157_9999999900',NULL),(10004,'admin','harishd','9999999999','','samidrawat@gmail.com','hr','Bathinda',NULL,'','2011','','','','',NULL,'testsssssssss',NULL,NULL,NULL,NULL,NULL,'2015-01-06','now()','sale','20153506013531771_9999999999',NULL),(10005,'admin','harish','9999999999','9999999999','samidrawat@gmail.com',NULL,'Bathinda',NULL,'as',NULL,'',NULL,NULL,NULL,NULL,'tesssssssssss','as','1111','1111111111',' 00','','2015-01-06','now()','service','20153606013600798_9999999999',NULL);

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
