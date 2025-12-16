/*
SQLyog Community v9.02 
MySQL - 5.1.35-community : Database - vsale
*********************************************************************
*/

/*!40101 SET NAMES utf8 */;

/*!40101 SET SQL_MODE=''*/;

/*!40014 SET @OLD_UNIQUE_CHECKS=@@UNIQUE_CHECKS, UNIQUE_CHECKS=0 */;
/*!40014 SET @OLD_FOREIGN_KEY_CHECKS=@@FOREIGN_KEY_CHECKS, FOREIGN_KEY_CHECKS=0 */;
/*!40101 SET @OLD_SQL_MODE=@@SQL_MODE, SQL_MODE='NO_AUTO_VALUE_ON_ZERO' */;
/*!40111 SET @OLD_SQL_NOTES=@@SQL_NOTES, SQL_NOTES=0 */;
CREATE DATABASE /*!32312 IF NOT EXISTS*/`vsale` /*!40100 DEFAULT CHARACTER SET latin1 */;

USE `vsale`;

/*Table structure for table `account` */

DROP TABLE IF EXISTS `account`;

CREATE TABLE `account` (
  `name1` varchar(50) NOT NULL,
  `pass` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `account` */

insert  into `account`(`name1`,`pass`) values ('negi','negi');

/*Table structure for table `admin` */

DROP TABLE IF EXISTS `admin`;

CREATE TABLE `admin` (
  `uname` varchar(50) DEFAULT NULL,
  `password` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `admin` */

insert  into `admin`(`uname`,`password`) values ('admin','admin'),('vshiksha','vshiksha123');

/*Table structure for table `did` */

DROP TABLE IF EXISTS `did`;

CREATE TABLE `did` (
  `id` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `did` */

/*Table structure for table `operator` */

DROP TABLE IF EXISTS `operator`;

CREATE TABLE `operator` (
  `name1` varchar(50) NOT NULL,
  `pass` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `operator` */

insert  into `operator`(`name1`,`pass`) values ('operator','operator');

/*Table structure for table `prepaid` */

DROP TABLE IF EXISTS `prepaid`;

CREATE TABLE `prepaid` (
  `prepaid` varchar(50) NOT NULL,
  `id` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `prepaid` */

/*Table structure for table `reject` */

DROP TABLE IF EXISTS `reject`;

CREATE TABLE `reject` (
  `did` varchar(50) DEFAULT NULL,
  `name1` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `mobile` varchar(50) NOT NULL,
  `alternate_no` varchar(50) DEFAULT NULL,
  `product` varchar(50) NOT NULL,
  `type1` varchar(50) NOT NULL,
  `choose_plan` varchar(50) NOT NULL,
  `city` varchar(50) NOT NULL,
  `state` varchar(50) NOT NULL,
  `profession` varchar(50) NOT NULL,
  `call_credit` varchar(50) NOT NULL,
  `period` varchar(50) NOT NULL,
  `mode1` varchar(50) NOT NULL,
  `con_call` varchar(50) NOT NULL,
  `message` varchar(500) NOT NULL,
  `recovery` varchar(50) NOT NULL,
  `payment` varchar(50) NOT NULL,
  `status1` varchar(50) DEFAULT NULL,
  `ticket` varchar(50) DEFAULT NULL,
  `record` varchar(50) DEFAULT NULL,
  `config` varchar(50) DEFAULT NULL,
  `test` varchar(50) DEFAULT NULL,
  `dat` varchar(50) DEFAULT NULL,
  `tim` varchar(50) DEFAULT NULL,
  `amount` varchar(50) DEFAULT NULL,
  `super1` varchar(50) DEFAULT NULL,
  `seller_name` varchar(50) DEFAULT NULL,
  `operator_name` varchar(50) DEFAULT NULL,
  `accountant_name` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `reject` */

/*Table structure for table `seller` */

DROP TABLE IF EXISTS `seller`;

CREATE TABLE `seller` (
  `name1` varchar(50) NOT NULL,
  `pass` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `seller` */

insert  into `seller`(`name1`,`pass`) values ('seller','seller');

/*Table structure for table `super1` */

DROP TABLE IF EXISTS `super1`;

CREATE TABLE `super1` (
  `name1` varchar(50) NOT NULL,
  `pass` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `super1` */

/*Table structure for table `support` */

DROP TABLE IF EXISTS `support`;

CREATE TABLE `support` (
  `name1` varchar(50) NOT NULL,
  `pass` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `support` */

/*Table structure for table `temp_super` */

DROP TABLE IF EXISTS `temp_super`;

CREATE TABLE `temp_super` (
  `did` varchar(50) DEFAULT NULL,
  `name1` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `mobile` varchar(50) NOT NULL,
  `alternate_no` varchar(50) DEFAULT NULL,
  `product` varchar(50) NOT NULL,
  `type1` varchar(50) NOT NULL,
  `choose_plan` varchar(50) NOT NULL,
  `city` varchar(50) NOT NULL,
  `state` varchar(50) NOT NULL,
  `profession` varchar(50) NOT NULL,
  `call_credit` varchar(50) NOT NULL,
  `period` varchar(50) NOT NULL,
  `mode1` varchar(50) NOT NULL,
  `con_call` varchar(50) NOT NULL,
  `message` varchar(500) NOT NULL,
  `recovery` varchar(50) NOT NULL,
  `payment` varchar(50) NOT NULL,
  `status1` varchar(50) DEFAULT NULL,
  `ticket` varchar(50) DEFAULT NULL,
  `record` varchar(50) DEFAULT NULL,
  `config` varchar(50) DEFAULT NULL,
  `test` varchar(50) DEFAULT NULL,
  `dat` varchar(50) DEFAULT NULL,
  `tim` varchar(50) DEFAULT NULL,
  `amount` varchar(50) DEFAULT NULL,
  `super1` varchar(50) DEFAULT NULL,
  `seller_name` varchar(50) DEFAULT NULL,
  `accountant_name` varchar(50) DEFAULT NULL,
  `operator_name` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `temp_super` */

/*Table structure for table `vseller` */

DROP TABLE IF EXISTS `vseller`;

CREATE TABLE `vseller` (
  `did` varchar(50) DEFAULT NULL,
  `name1` varchar(50) NOT NULL,
  `email` varchar(50) NOT NULL,
  `mobile` varchar(50) NOT NULL,
  `alternate_no` varchar(50) DEFAULT NULL,
  `product` varchar(50) DEFAULT NULL,
  `type1` varchar(50) NOT NULL,
  `choose_plan` varchar(50) NOT NULL,
  `city` varchar(50) NOT NULL,
  `state` varchar(50) NOT NULL,
  `profession` varchar(50) NOT NULL,
  `call_credit` varchar(50) NOT NULL,
  `period` varchar(50) NOT NULL,
  `mode1` varchar(50) NOT NULL,
  `con_call` varchar(50) NOT NULL,
  `message` varchar(500) NOT NULL,
  `recovery` varchar(50) NOT NULL,
  `payment` varchar(50) NOT NULL,
  `status1` varchar(50) DEFAULT NULL,
  `ticket` varchar(50) DEFAULT NULL,
  `record` varchar(50) DEFAULT NULL,
  `config` varchar(50) DEFAULT NULL,
  `test` varchar(50) DEFAULT NULL,
  `dat` varchar(50) DEFAULT NULL,
  `tim` varchar(50) DEFAULT NULL,
  `amount` varchar(50) DEFAULT NULL,
  `super1` varchar(50) DEFAULT NULL,
  `seller_name` varchar(50) DEFAULT NULL,
  `accountant_name` varchar(50) DEFAULT NULL,
  `operator_name` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1;

/*Data for the table `vseller` */

/*!40101 SET SQL_MODE=@OLD_SQL_MODE */;
/*!40014 SET FOREIGN_KEY_CHECKS=@OLD_FOREIGN_KEY_CHECKS */;
/*!40014 SET UNIQUE_CHECKS=@OLD_UNIQUE_CHECKS */;
/*!40111 SET SQL_NOTES=@OLD_SQL_NOTES */;
