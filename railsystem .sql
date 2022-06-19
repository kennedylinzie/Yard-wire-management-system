-- phpMyAdmin SQL Dump
-- version 5.0.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: Dec 06, 2021 at 01:58 PM
-- Server version: 10.4.11-MariaDB
-- PHP Version: 7.4.2

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
SET AUTOCOMMIT = 0;
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `railsystem`
--

-- --------------------------------------------------------

--
-- Table structure for table `all_data`
--

CREATE TABLE `all_data` (
  `transaction_id` int(20) NOT NULL,
  `Relesed_from_system` varchar(12) NOT NULL,
  `Vehicle_Type` varchar(50) DEFAULT NULL,
  `Yard_Sector` varchar(50) DEFAULT NULL,
  `Line` varchar(50) DEFAULT NULL,
  `Vehicle` varchar(50) DEFAULT NULL,
  `Sequence` varchar(50) NOT NULL,
  `Wagon_type` varchar(50) DEFAULT NULL,
  `Series` varchar(50) DEFAULT NULL,
  `Date_Hour_Last_Event` varchar(50) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL,
  `posX` varchar(50) NOT NULL,
  `posY` varchar(50) NOT NULL,
  `Data_home` varchar(100) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Dumping data for table `all_data`
--

INSERT INTO `all_data` (`transaction_id`, `Relesed_from_system`, `Vehicle_Type`, `Yard_Sector`, `Line`, `Vehicle`, `Sequence`, `Wagon_type`, `Series`, `Date_Hour_Last_Event`, `Status`, `posX`, `posY`, `Data_home`) VALUES
(2, 'yes', 'Wagon', 'limbe', '6', '8601', '', 'FLAT WAGON', 'LSB', 'Sunday, 21 November 2021 18:06:11', 'damaged', '-17.00854', '215.8448', ''),
(3, 'yes', 'Wagon', 'limbe', '6', '6995', '', 'COVERED', 'CB0', 'Sunday, 21 November 2021 18:00:26', 'repair', '-133.0086', '215.8448', ''),
(4, 'yes', 'Wagon', 'limbe', '6', '6801', '', 'COVERED', 'CB0', 'Sunday, 21 November 2021 18:01:09', 'ofloading', '-17.00854', '215.8448', ''),
(5, 'yes', 'Wagon', 'limbe', '5', '8403', '', 'PASSENGER CAR', 'TC8', 'Sunday, 21 November 2021 21:20:11', 'repair', '574.9914', '129.8448', ''),
(6, 'yes', 'Wagon', 'limbe', '6', '8410', '', 'PASSENGER CAR', 'TC8', '0', 'repair', '-17.00854', '215.8448', ''),
(7, 'yes', 'Wagon', 'limbe', '', '8415', '', 'PASSENGER CAR', 'TC8', '0', '', '', '', ''),
(8, 'yes', 'Wagon', 'limbe', '', '8401', '', 'PASSENGER CAR', 'TC8', '0', '', '', '', ''),
(9, 'no', 'Wagon', 'limbe', '6', '8402', '', 'PASSENGER CAR', 'TC8', '0', '', '100.9914', '215.8448', 'PASSENGER CAR11/29/2021 12:40 PM'),
(10, 'yes', 'Wagon', 'limbe', '', '8405', '', 'PASSENGER CAR', 'TC8', '0', '', '', '', ''),
(11, 'yes', 'Wagon', 'limbe', '', '8404', '', 'PASSENGER CAR', 'TC8', '0', '', '', '', ''),
(12, 'no', 'Wagon', 'limbe', '6', '3040', '', 'FLAT WAGON', 'U30', 'Sunday, 21 November 2021 21:21:03', 'offloading', '216.9914', '215.8448', 'FLAT WAGON11/29/2021 12:42 PM'),
(13, 'yes', 'Wagon', 'limbe', '3', '6806', '', 'COVERED', 'CB0', '0', '', '27.99145', '-59.15503', ''),
(14, 'yes', 'Wagon', 'limbe', '', '6804', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(15, 'yes', 'Wagon', 'limbe', '', '8561', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(16, 'yes', 'Wagon', 'limbe', '', '8409', '', 'PASSENGER CAR', 'TC8', '0', '', '', '', ''),
(17, 'yes', 'Wagon', 'limbe', '', '8407', '', 'PASSENGER CAR', 'TC8', '0', '', '', '', ''),
(18, 'no', 'Wagon', 'limbe', '6', '8411', '', 'PASSENGER CAR', 'TC8', '0', 'EMPTY', '100.9914', '215.8448', 'PASSENGER CAR11/29/2021 12:40 PM'),
(19, 'yes', 'Wagon', 'limbe', '', '48017', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(20, 'yes', 'Wagon', 'limbe', '', '3036', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(21, 'yes', 'Wagon', 'limbe', '', '4494', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(22, 'yes', 'Wagon', 'limbe', '', '4161', '', 'GONDOLA', 'BBA', '0', '', '', '', ''),
(23, 'no', 'Wagon', 'limbe', '6', '4164', '', 'GONDOLA', 'BBA', '0', '', '-17.00854', '215.8448', 'GONDOLA11/29/2021 12:57 PM'),
(24, 'yes', 'Wagon', 'limbe', '', '3029', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(25, 'yes', 'Wagon', 'limbe', '23', '6162', '', 'COVERED', 'CB0', 'Sunday, 28 November 2021 22:02:36', 'ofloading', '', '', ''),
(26, 'yes', 'Wagon', 'limbe', '', '4266', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(27, 'yes', 'Wagon', 'limbe', '', '48090', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(28, 'yes', 'Wagon', 'limbe', '', '5725', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(29, 'yes', 'Wagon', 'limbe', '', '6200', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(30, 'yes', 'Wagon', 'limbe', '', '6273', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(31, 'yes', 'Wagon', 'limbe', '', '4231', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(32, 'no', 'Wagon', 'limbe', '6', '4188', '', 'GONDOLA', 'BBA', '0', '', '-17.00854', '215.8448', 'GONDOLA11/29/2021 12:57 PM'),
(33, 'no', 'Wagon', 'limbe', '6', '4183', '', 'GONDOLA', 'BBA', '0', '', '-17.00854', '215.8448', 'GONDOLA11/29/2021 12:57 PM'),
(34, 'no', 'Wagon', 'limbe', '6', '4181', '', 'GONDOLA', 'BBA', '0', '', '-17.00854', '215.8448', 'GONDOLA11/29/2021 12:57 PM'),
(35, 'no', 'Wagon', 'limbe', '6', '4167', '', 'GONDOLA', 'BBA', '0', '', '-17.00854', '215.8448', 'GONDOLA11/29/2021 12:57 PM'),
(36, 'no', 'Wagon', 'limbe', '6', '4189', '', 'GONDOLA', 'BBA', '0', '', '-17.00854', '215.8448', 'GONDOLA11/29/2021 12:57 PM'),
(37, 'yes', 'Wagon', 'limbe', '', '1041660', '', 'GONDOLA', 'BBA', '0', '', '', '', ''),
(38, 'yes', 'Wagon', 'limbe', '', '1041700', '', 'GONDOLA', 'BBA', '0', '', '', '', ''),
(39, 'yes', 'Wagon', 'limbe', '', '1041750', '', 'GONDOLA', 'BBA', '0', '', '', '', ''),
(40, 'yes', 'Wagon', 'limbe', '', '1041864', '', 'GONDOLA', 'BBA', '0', '', '', '', ''),
(41, 'yes', 'Wagon', 'limbe', '', '3017', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(42, 'yes', 'Wagon', 'limbe', '', '6818', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(43, 'yes', 'Wagon', 'limbe', '', '0085520', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(44, 'yes', 'Wagon', 'limbe', '', '3018', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(45, 'yes', 'Wagon', 'limbe', '', '4517', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(46, 'yes', 'Wagon', 'limbe', '', '4219', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(47, 'yes', 'Wagon', 'limbe', '', '1041770', '', 'GONDOLA', 'BBA', '0', '', '', '', ''),
(48, 'yes', 'Wagon', 'limbe', '', '7109', '', 'TANK', 'FT7', '0', '', '', '', ''),
(49, 'yes', 'Wagon', 'limbe', '', '7113', '', 'TANK', 'FT7', '0', '', '', '', ''),
(50, 'yes', 'Wagon', 'limbe', '', '7338', '', 'TANK', 'FT7', '0', '', '', '', ''),
(51, 'yes', 'Wagon', 'limbe', '', '7024', '', 'TANK', 'FT7', '0', '', '', '', ''),
(52, 'no', 'Wagon', 'limbe', '6', '7014', '', 'TANK', 'FT7', '0', '', '-253.0086', '215.8448', 'TANK11/29/2021 12:49 PM'),
(53, 'yes', 'Wagon', 'limbe', '', '7103', '', 'TANK', 'FT7', '0', '', '', '', ''),
(54, 'yes', 'Wagon', 'limbe', '', '3054', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(55, 'yes', 'Wagon', 'limbe', '', '4182', '', 'GONDOLA', 'BBA', '0', '', '', '', ''),
(56, 'yes', 'Wagon', 'limbe', '', '5739', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(57, 'yes', 'Wagon', 'limbe', '', '4213', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(58, 'yes', 'Wagon', 'limbe', '', '4535', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(59, 'yes', 'Wagon', 'limbe', '', '6172', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(60, 'yes', 'Wagon', 'limbe', '', '3034', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(61, 'yes', 'Wagon', 'limbe', '', '48075', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(62, 'yes', 'Wagon', 'limbe', '', '4492', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(63, 'yes', 'Wagon', 'limbe', '', '4168', '', 'GONDOLA', 'BBA', '0', '', '', '', ''),
(64, 'no', 'Wagon', 'limbe', '6', '7334', '', 'TANK', 'FT7', '0', '', '-253.0086', '215.8448', 'TANK11/29/2021 12:49 PM'),
(65, 'yes', 'Wagon', 'limbe', '', '4495', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(66, 'yes', 'Wagon', 'limbe', '', '6216', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(67, 'yes', 'Wagon', 'limbe', '', '871288-2', '', 'GONDOLA', 'BBW', '0', '', '', '', ''),
(68, 'yes', 'Wagon', 'limbe', '', '4234', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(69, 'yes', 'Wagon', 'limbe', '', '5740', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(70, 'yes', 'Wagon', 'limbe', '', '4524', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(71, 'yes', 'Wagon', 'limbe', '', '4491', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(72, 'yes', 'Wagon', 'limbe', '', '8412', '', 'PASSENGER CAR', 'TC8', '0', '', '', '', ''),
(73, 'yes', 'Wagon', 'limbe', '', '8414', '', 'PASSENGER CAR', 'TC8', '0', '', '', '', ''),
(74, 'yes', 'Wagon', 'limbe', '', '6802', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(75, 'yes', 'Wagon', 'limbe', '', '4190', '', 'GONDOLA', 'BBA', '0', '', '', '', ''),
(76, 'no', 'Wagon', 'limbe', '6', '4185', '', 'GONDOLA', 'BBA', '0', '', '-17.00854', '215.8448', 'GONDOLA11/29/2021 12:57 PM'),
(77, 'yes', 'Wagon', 'limbe', '', '5762', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(78, 'yes', 'Wagon', 'limbe', '', '6479', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(79, 'yes', 'Wagon', 'limbe', '', '4496', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(80, 'yes', 'Wagon', 'limbe', '', '6176', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(81, 'yes', 'Wagon', 'limbe', '', '4260', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(82, 'yes', 'Wagon', 'limbe', '', '6819', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(83, 'yes', 'Wagon', 'limbe', '', '6820', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(84, 'yes', 'Wagon', 'limbe', '', '4233', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(85, 'yes', 'Wagon', 'limbe', '', '4204', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(86, 'yes', 'Wagon', 'limbe', '', '7104', '', 'TANK', 'FT7', '0', '', '', '', ''),
(87, 'yes', 'Wagon', 'limbe', '', '7029', '', 'TANK', 'FT7', '0', '', '', '', ''),
(88, 'yes', 'Wagon', 'limbe', '', '7019', '', 'TANK', 'FT7', '0', '', '', '', ''),
(89, 'yes', 'Wagon', 'limbe', '', '7108', '', 'TANK', 'FT7', '0', '', '', '', ''),
(90, 'yes', 'Wagon', 'limbe', '', '7303', '', 'TANK', 'FT7', '0', '', '', '', ''),
(91, 'yes', 'Wagon', 'limbe', '', '7111', '', 'TANK', 'FT7', '0', '', '', '', ''),
(92, 'yes', 'Wagon', 'limbe', '', '7020', '', 'TANK', 'FT7', '0', '', '', '', ''),
(93, 'yes', 'Wagon', 'limbe', '', '4915', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(94, 'yes', 'Wagon', 'limbe', '', '6195', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(95, 'yes', 'Wagon', 'limbe', '', '8406', '', 'PASSENGER CAR', 'TC8', '0', '', '', '', ''),
(96, 'yes', 'Wagon', 'limbe', '', '7006', '', 'TANK', 'FT7', '0', '', '', '', ''),
(97, 'yes', 'Wagon', 'limbe', '', '7016', '', 'TANK', 'FT7', '0', '', '', '', ''),
(98, 'yes', 'Wagon', 'limbe', '', '7317', '', 'TANK', 'FT7', '0', '', '', '', ''),
(99, 'yes', 'Wagon', 'limbe', '', '48084', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(100, 'yes', 'Wagon', 'limbe', '', '48027', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(101, 'yes', 'Wagon', 'limbe', '', '7105', '', 'TANK', 'FT7', '0', '', '', '', ''),
(102, 'yes', 'Wagon', 'limbe', '', '7308', '', 'TANK', 'FT7', '0', '', '', '', ''),
(103, 'yes', 'Wagon', 'limbe', '', '3023', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(104, 'yes', 'Wagon', 'limbe', '', '3046', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(105, 'yes', 'Wagon', 'limbe', '', '48108', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(106, 'yes', 'Wagon', 'limbe', '', '6916', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(107, 'yes', 'Wagon', 'limbe', '', '4906', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(108, 'yes', 'Wagon', 'limbe', '', '4512', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(109, 'yes', 'Wagon', 'limbe', '', '4224', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(110, 'yes', 'Wagon', 'limbe', '', '4252', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(111, 'yes', 'Wagon', 'limbe', '', '4916', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(112, 'yes', 'Wagon', 'limbe', '', '48101', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(113, 'yes', 'Wagon', 'limbe', '', '7312', '', 'TANK', 'FT7', '0', '', '', '', ''),
(114, 'yes', 'Wagon', 'limbe', '', '7004', '', 'TANK', 'FT7', '0', '', '', '', ''),
(115, 'yes', 'Wagon', 'limbe', '', '7314', '', 'TANK', 'FT7', '0', '', '', '', ''),
(116, 'yes', 'Wagon', 'limbe', '', '7102', '', 'TANK', 'FT7', '0', '', '', '', ''),
(117, 'yes', 'Wagon', 'limbe', '', '7034', '', 'TANK', 'FT7', '0', '', '', '', ''),
(118, 'yes', 'Wagon', 'limbe', '', '7015', '', 'TANK', 'FT7', '0', '', '', '', ''),
(119, 'no', 'Wagon', 'limbe', '6', '7307', '', 'TANK', 'FT7', '0', '', '-253.0086', '215.8448', 'TANK11/29/2021 12:49 PM'),
(120, 'no', 'Wagon', 'limbe', '6', '7032', '', 'TANK', 'FT7', '0', '', '-253.0086', '215.8448', 'TANK11/29/2021 12:49 PM'),
(121, 'no', 'Wagon', 'limbe', '6', '7033', '', 'TANK', 'FT7', '0', '', '-253.0086', '215.8448', 'TANK11/29/2021 12:49 PM'),
(122, 'yes', 'Wagon', 'limbe', '', '7005', '', 'TANK', 'FT7', '0', '', '', '', ''),
(123, 'yes', 'Wagon', 'limbe', '', '7107', '', 'TANK', 'FT7', '0', '', '', '', ''),
(124, 'yes', 'Wagon', 'limbe', '', '7101', '', 'TANK', 'FT7', '0', '', '', '', ''),
(125, 'yes', 'Wagon', 'limbe', '', '7013', '', 'TANK', 'FT7', '0', '', '', '', ''),
(126, 'yes', 'Wagon', 'limbe', '', '7330', '', 'TANK', 'FT7', '0', '', '', '', ''),
(127, 'no', 'Wagon', 'limbe', '6', '7326', '', 'TANK', 'FT7', '0', '', '-253.0086', '215.8448', 'TANK11/29/2021 12:49 PM'),
(128, 'yes', 'Wagon', 'limbe', '', '7324', '', 'TANK', 'FT7', '0', '', '', '', ''),
(129, 'yes', 'Wagon', 'limbe', '', '7018', '', 'TANK', 'FT7', '0', '', '', '', ''),
(130, 'yes', 'Wagon', 'limbe', '', '4538', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(131, 'no', 'Wagon', 'limbe', '6', '4922', '', 'FLAT WAGON', 'LSB', '0', '', '216.9914', '215.8448', 'FLAT WAGON11/29/2021 12:42 PM'),
(132, 'yes', 'Wagon', 'limbe', '', '1041725', '', 'GONDOLA', 'BBA', '0', '', '', '', ''),
(133, 'yes', 'Wagon', 'limbe', '', '3024', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(134, 'yes', 'Wagon', 'limbe', '', '3001', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(135, 'yes', 'Wagon', 'limbe', '', '3059', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(136, 'yes', 'Wagon', 'limbe', '', '4901', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(137, 'yes', 'Wagon', 'limbe', '', '4254', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(138, 'yes', 'Wagon', 'limbe', '', '3163193', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(139, 'yes', 'Wagon', 'limbe', '', '3163203', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(140, 'yes', 'Wagon', 'limbe', '', '3165036', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(141, 'yes', 'Wagon', 'limbe', '', '3165049', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(142, 'yes', 'Wagon', 'limbe', '', '3159330', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(143, 'yes', 'Wagon', 'limbe', '', '3159343', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(144, 'yes', 'Wagon', 'limbe', '', '3163232', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(145, 'yes', 'Wagon', 'limbe', '', '3163245', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(146, 'yes', 'Wagon', 'limbe', '', '48034', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(147, 'yes', 'Wagon', 'limbe', '', '48094', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(148, 'yes', 'Wagon', 'limbe', '', '48076', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(149, 'yes', 'Wagon', 'limbe', '', '48063', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(150, 'yes', 'Wagon', 'limbe', '', '3171839', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(151, 'yes', 'Wagon', 'limbe', '', '3173002', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(152, 'yes', 'Wagon', 'limbe', '', '3168758', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(153, 'yes', 'Wagon', 'limbe', '', '3168761', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(154, 'yes', 'Wagon', 'limbe', '', '3150766', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(155, 'yes', 'Wagon', 'limbe', '', '3150753', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(156, 'yes', 'Wagon', 'limbe', '', '3162262', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(157, 'yes', 'Wagon', 'limbe', '', '3162259', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(158, 'yes', 'Wagon', 'limbe', '', '3172773', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(159, 'yes', 'Wagon', 'limbe', '', '3173206', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(160, 'yes', 'Wagon', 'limbe', '', '3160196', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(161, 'yes', 'Wagon', 'limbe', '', '3160206', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(162, 'yes', 'Wagon', 'limbe', '', '6938', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(163, 'yes', 'Wagon', 'limbe', '', '6942', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(164, 'yes', 'Wagon', 'limbe', '', '6168', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(165, 'yes', 'Wagon', 'limbe', '', '6957', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(166, 'yes', 'Wagon', 'limbe', '', '6227', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(167, 'yes', 'Wagon', 'limbe', '', '6523', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(168, 'yes', 'Wagon', 'limbe', '', '6944', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(169, 'yes', 'Wagon', 'limbe', '', '8413', '', 'PASSENGER CAR', 'TC8', '0', '', '', '', ''),
(170, 'yes', 'Wagon', 'limbe', '', '6219', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(171, 'yes', 'Wagon', 'limbe', '', '6924', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(172, 'yes', 'Wagon', 'limbe', '', '6925', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(173, 'yes', 'Wagon', 'limbe', '', '6280', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(174, 'yes', 'Wagon', 'limbe', '', '6986', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(175, 'yes', 'Wagon', 'limbe', '', '6208', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(176, 'yes', 'Wagon', 'limbe', '', '6931', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(177, 'yes', 'Wagon', 'limbe', '', '6950', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(178, 'yes', 'Wagon', 'limbe', '', '6249', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(179, 'yes', 'Wagon', 'limbe', '', '6943', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(180, 'yes', 'Wagon', 'limbe', '', '6968', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(181, 'yes', 'Wagon', 'limbe', '', '6985', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(182, 'yes', 'Wagon', 'limbe', '', '6250', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(183, 'yes', 'Wagon', 'limbe', '', '6945', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(184, 'yes', 'Wagon', 'limbe', '', '8408', '', 'PASSENGER CAR', 'TC8', '0', '', '', '', ''),
(185, 'yes', 'Wagon', 'limbe', '', '48019', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(186, 'yes', 'Wagon', 'limbe', '', '6235', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(187, 'yes', 'Wagon', 'limbe', '', '4793', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(188, 'yes', 'Wagon', 'limbe', '', '5692', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(189, 'yes', 'Wagon', 'limbe', '', '5756', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(190, 'yes', 'Wagon', 'limbe', '', '5726', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(191, 'yes', 'Wagon', 'limbe', '', '4523', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(192, 'yes', 'Wagon', 'limbe', '', '5722', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(193, 'yes', 'Wagon', 'limbe', '', '5771', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(194, 'yes', 'Wagon', 'limbe', '', '8110038', '', 'HOPPER', 'HF1', '0', '', '', '', ''),
(195, 'yes', 'Wagon', 'limbe', '', '8110892', '', 'HOPPER', 'HF1', '0', '', '', '', ''),
(196, 'yes', 'Wagon', 'limbe', '', '6525', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(197, 'yes', 'Wagon', 'limbe', '', '48099', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(198, 'yes', 'Wagon', 'limbe', '', '5751', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(199, 'yes', 'Wagon', 'limbe', '', '6260', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(200, 'yes', 'Wagon', 'limbe', '', '8110244', '', 'HOPPER', 'HF1', '0', '', '', '', ''),
(201, 'yes', 'Wagon', 'limbe', '', '5730', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(202, 'yes', 'Wagon', 'limbe', '', '5768', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(203, 'yes', 'Wagon', 'limbe', '', '48120', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(204, 'no', 'Wagon', 'limbe', '6', '48068', '', 'FLAT WAGON', 'LSB', '0', '', '216.9914', '215.8448', 'FLAT WAGON11/29/2021 12:42 PM'),
(205, 'yes', 'Wagon', 'limbe', '', '48102', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(206, 'yes', 'Wagon', 'limbe', '', '3176915', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(207, 'yes', 'Wagon', 'limbe', '', '3176928', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(208, 'yes', 'Wagon', 'limbe', '', '48079', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(209, 'yes', 'Wagon', 'limbe', '', '48051', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(210, 'yes', 'Wagon', 'limbe', '', '3157390', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(211, 'yes', 'Wagon', 'limbe', '', '3157400', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(212, 'yes', 'Wagon', 'limbe', '', '3160510', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(213, 'yes', 'Wagon', 'limbe', '', '3160523', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(214, 'yes', 'Wagon', 'limbe', '', '3159628', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(215, 'yes', 'Wagon', 'limbe', '', '3159615', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(216, 'yes', 'Wagon', 'limbe', '', '3163151', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(217, 'yes', 'Wagon', 'limbe', '', '3163164', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(218, 'yes', 'Wagon', 'limbe', '', '3165298', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(219, 'yes', 'Wagon', 'limbe', '', '3165308', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(220, 'yes', 'Wagon', 'limbe', '', '3153996', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(221, 'yes', 'Wagon', 'limbe', '', '3154005', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(222, 'yes', 'Wagon', 'limbe', '', '3165104', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(223, 'yes', 'Wagon', 'limbe', '', '3165094', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(224, 'yes', 'Wagon', 'limbe', '', '3151451', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(225, 'yes', 'Wagon', 'limbe', '', '3151464', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(226, 'yes', 'Wagon', 'limbe', '', '3039', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(227, 'yes', 'Wagon', 'limbe', '', '1041740', '', 'GONDOLA', 'BBA', '0', '', '', '', ''),
(228, 'yes', 'Wagon', 'limbe', '', '1041630', '', 'GONDOLA', 'BBA', '0', '', '', '', ''),
(229, 'yes', 'Wagon', 'limbe', '', '4173', '', 'GONDOLA', 'BBA', '0', '', '', '', ''),
(230, 'yes', 'Wagon', 'limbe', '', '8110646', '', 'HOPPER', 'HF1', '0', '', '', '', ''),
(231, 'yes', 'Wagon', 'limbe', '', '4516', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(232, 'yes', 'Wagon', 'limbe', '', '6243', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(233, 'yes', 'Wagon', 'limbe', '', '8110018', '', 'HOPPER', 'HF1', '0', '', '', '', ''),
(234, 'yes', 'Wagon', 'limbe', '', '5749', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(235, 'yes', 'Wagon', 'limbe', '', '5789', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(236, 'yes', 'Wagon', 'limbe', '', '4501', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(237, 'yes', 'Wagon', 'limbe', '', '6522', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(238, 'yes', 'Wagon', 'limbe', '', '4250', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(239, 'yes', 'Wagon', 'limbe', '', '48124', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(240, 'yes', 'Wagon', 'limbe', '', '8602', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(241, 'yes', 'Wagon', 'limbe', '', '4920', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(242, 'yes', 'Wagon', 'limbe', '', '4789', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(243, 'yes', 'Wagon', 'limbe', '', '4918', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(244, 'yes', 'Wagon', 'limbe', '', '4925', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(245, 'yes', 'Wagon', 'limbe', '', '5796', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(246, 'yes', 'Wagon', 'limbe', '', '3172715', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(247, 'yes', 'Wagon', 'limbe', '', '3172443', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(248, 'yes', 'Wagon', 'limbe', '', '3169977', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(249, 'yes', 'Wagon', 'limbe', '', '3169980', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(250, 'yes', 'Wagon', 'limbe', '', '4525', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(251, 'yes', 'Wagon', 'limbe', '', '3176423', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(252, 'yes', 'Wagon', 'limbe', '', '3176410', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(253, 'yes', 'Wagon', 'limbe', '', '3002', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(254, 'yes', 'Wagon', 'limbe', '', '48010', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(255, 'yes', 'Wagon', 'limbe', '', '3176465', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(256, 'yes', 'Wagon', 'limbe', '', '3176452', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(257, 'yes', 'Wagon', 'limbe', '', '3043', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(258, 'yes', 'Wagon', 'limbe', '', '4236', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(259, 'yes', 'Wagon', 'limbe', '', '3021', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(260, 'yes', 'Wagon', 'limbe', '', '3028', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(261, 'yes', 'Wagon', 'limbe', '', '4251', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(262, 'yes', 'Wagon', 'limbe', '', '3051', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(263, 'yes', 'Wagon', 'limbe', '', '4270', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(264, 'yes', 'Wagon', 'limbe', '', '3006', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(265, 'yes', 'Wagon', 'limbe', '', '3167092', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(266, 'yes', 'Wagon', 'limbe', '', '3167102', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(267, 'yes', 'Wagon', 'limbe', '', '3152269', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(268, 'yes', 'Wagon', 'limbe', '', '3152256', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(269, 'yes', 'Wagon', 'limbe', '', '3168512', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(270, 'yes', 'Wagon', 'limbe', '', '3168525', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(271, 'yes', 'Wagon', 'limbe', '', '3161483', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(272, 'yes', 'Wagon', 'limbe', '', '3161470', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(273, 'yes', 'Wagon', 'limbe', '', '3171923', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(274, 'yes', 'Wagon', 'limbe', '', '3171897', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(275, 'yes', 'Wagon', 'limbe', '', '3150782', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(276, 'yes', 'Wagon', 'limbe', '', '3150779', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(277, 'yes', 'Wagon', 'limbe', '', '3164642', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(278, 'yes', 'Wagon', 'limbe', '', '3164639', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(279, 'yes', 'Wagon', 'limbe', '', '3015', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(280, 'yes', 'Wagon', 'limbe', '', '48096', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(281, 'yes', 'Wagon', 'limbe', '', '3152463', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(282, 'yes', 'Wagon', 'limbe', '', '3152450', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(283, 'no', 'Wagon', 'limbe', '6', '8110543', '', 'HOPPER', 'HF1', '0', '', '-133.0086', '215.8448', 'HOPPER11/29/2021 12:02 PM'),
(284, 'no', 'Wagon', 'limbe', '6', '8110028', '', 'HOPPER', 'HF1', '0', '', '-133.0086', '215.8448', 'HOPPER11/29/2021 12:02 PM'),
(285, 'no', 'Wagon', 'limbe', '6', '8110088', '', 'HOPPER', 'HF1', 'Monday, 29 November 2021 12:06:38', 'loaded', '-133.0086', '215.8448', 'HOPPER11/29/2021 12:02 PM'),
(286, 'no', 'Wagon', 'limbe', '6', '8110905', '', 'HOPPER', 'HF1', '0', '', '-133.0086', '215.8448', 'HOPPER11/29/2021 12:02 PM'),
(287, 'no', 'Wagon', 'limbe', '6', '8110719', '', 'HOPPER', 'HF1', '0', '', '-133.0086', '215.8448', 'HOPPER11/29/2021 12:02 PM'),
(288, 'yes', 'Wagon', 'limbe', '', '3152641', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(289, 'yes', 'Wagon', 'limbe', '', '3152638', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(290, 'yes', 'Wagon', 'limbe', '', '3158548', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(291, 'yes', 'Wagon', 'limbe', '', '3158535', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(292, 'yes', 'Wagon', 'limbe', '', '3169524', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(293, 'yes', 'Wagon', 'limbe', '', '3169511', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(294, 'yes', 'Wagon', 'limbe', '', '5775', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(295, 'yes', 'Wagon', 'limbe', '', '7031', '', 'TANK', 'FT7', '0', '', '', '', ''),
(296, 'yes', 'Wagon', 'limbe', '', '7115', '', 'TANK', 'FT7', '0', '', '', '', ''),
(297, 'yes', 'Wagon', 'limbe', '', '7112', '', 'TANK', 'FT7', '0', '', '', '', ''),
(298, 'yes', 'Wagon', 'limbe', '', '48041', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(299, 'yes', 'Wagon', 'limbe', '', '48069', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(300, 'yes', 'Wagon', 'limbe', '', '48003', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(301, 'yes', 'Wagon', 'limbe', '', '48109', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(302, 'yes', 'Wagon', 'limbe', '', '48105', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(303, 'yes', 'Wagon', 'limbe', '', '48001', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(304, 'yes', 'Wagon', 'limbe', '', '48104', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(305, 'yes', 'Wagon', 'limbe', '', '48081', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(306, 'yes', 'Wagon', 'limbe', '', '48078', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(307, 'yes', 'Wagon', 'limbe', '', '48065', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(308, 'yes', 'Wagon', 'limbe', '', '48073', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(309, 'yes', 'Wagon', 'limbe', '', '48077', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(310, 'yes', 'Wagon', 'limbe', '', '48111', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(311, 'yes', 'Wagon', 'limbe', '', '48005', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(312, 'yes', 'Wagon', 'limbe', '', '48035', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(313, 'yes', 'Wagon', 'limbe', '', '48080', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(314, 'yes', 'Wagon', 'limbe', '', '48049', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(315, 'yes', 'Wagon', 'limbe', '', '48013', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(316, 'yes', 'Wagon', 'limbe', '', '48054', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(317, 'yes', 'Wagon', 'limbe', '', '48060', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(318, 'yes', 'Wagon', 'limbe', '', '48018', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(319, 'yes', 'Wagon', 'limbe', '', '48086', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(320, 'yes', 'Wagon', 'limbe', '', '48033', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(321, 'yes', 'Wagon', 'limbe', '', '48114', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(322, 'yes', 'Wagon', 'limbe', '', '48053', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(323, 'yes', 'Wagon', 'limbe', '', '48025', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(324, 'yes', 'Wagon', 'limbe', '', '48121', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(325, 'yes', 'Wagon', 'limbe', '', '48044', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(326, 'yes', 'Wagon', 'limbe', '', '48117', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(327, 'yes', 'Wagon', 'limbe', '', '48011', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(328, 'yes', 'Wagon', 'limbe', '', '48066', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(329, 'yes', 'Wagon', 'limbe', '', '48042', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(330, 'yes', 'Wagon', 'limbe', '', '48037', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(331, 'yes', 'Wagon', 'limbe', '', '48009', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(332, 'yes', 'Wagon', 'limbe', '', '5741', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(333, 'yes', 'Wagon', 'limbe', '', '5788', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(334, 'yes', 'Wagon', 'limbe', '', '5765', '', 'GONDOLA', 'HSB', '0', '', '', '', ''),
(335, 'yes', 'Wagon', 'limbe', '', '8003', '', 'PASSENGER CAR', 'TC8', '0', '', '', '', ''),
(336, 'yes', 'Wagon', 'limbe', '', '8008', '', 'PASSENGER CAR', 'TC8', '0', '', '', '', ''),
(337, 'yes', 'Wagon', 'limbe', '', '4497', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(338, 'no', 'Wagon', 'limbe', '6', '4179', '', 'GONDOLA', 'BBA', '0', '', '-17.00854', '215.8448', 'GONDOLA11/29/2021 12:57 PM'),
(339, 'yes', 'Wagon', 'limbe', '', '4268', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(340, 'yes', 'Wagon', 'limbe', '', '4216', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(341, 'yes', 'Wagon', 'limbe', '', '3033', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(342, 'yes', 'Wagon', 'limbe', '', '3045', '', 'FLAT WAGON', 'U30', '0', '', '', '', ''),
(343, 'yes', 'Wagon', 'limbe', '', '4210', '', 'FLAT WAGON', 'LSB', '0', '', '', '', ''),
(344, 'yes', 'Wagon', 'limbe', '', '6814', '', 'COVERED', 'CB0', '0', '', '', '', ''),
(345, 'yes', 'Wagon', 'limbe', '', '3176698', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(346, 'yes', 'Wagon', 'limbe', '', '3176708', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(347, 'yes', 'Wagon', 'limbe', '', '3169935', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(348, 'yes', 'Wagon', 'limbe', '', '3169948', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(349, 'yes', 'Wagon', 'limbe', '', '3172431', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(350, 'yes', 'Wagon', 'limbe', '', '3171402', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(351, 'yes', 'Wagon', 'limbe', '', '3174713', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(352, 'yes', 'Wagon', 'limbe', '', '3174865', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(353, 'yes', 'Wagon', 'limbe', '', '3168774', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(354, 'yes', 'Wagon', 'limbe', '', '3168787', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(355, 'yes', 'Wagon', 'limbe', '', '3152670', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(356, 'yes', 'Wagon', 'limbe', '', '3152683', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(357, 'yes', 'Wagon', 'limbe', '', '3154830', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(358, 'yes', 'Wagon', 'limbe', '', '3154843', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(359, 'yes', 'Wagon', 'limbe', '', '3150973', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(360, 'yes', 'Wagon', 'limbe', '', '3150986', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(361, 'yes', 'Wagon', 'limbe', '', '3159217', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(362, 'yes', 'Wagon', 'limbe', '', '3159220', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(363, 'yes', 'Wagon', 'limbe', '', '3162495', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(364, 'yes', 'Wagon', 'limbe', '', '3162505', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(365, 'yes', 'Wagon', 'limbe', '', '3167937', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(366, 'yes', 'Wagon', 'limbe', '', '3167940', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(367, 'yes', 'Wagon', 'limbe', '', '3163070', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(368, 'yes', 'Wagon', 'limbe', '', '3163083', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(369, 'yes', 'Wagon', 'limbe', '', '3155651', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(370, 'yes', 'Wagon', 'limbe', '', '3155664', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(371, 'yes', 'Wagon', 'limbe', '', '3165395', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(372, 'yes', 'Wagon', 'limbe', '', '3165405', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(373, 'yes', 'Wagon', 'limbe', '', '3150630', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(374, 'yes', 'Wagon', 'limbe', '', '3150643', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(375, 'yes', 'Wagon', 'limbe', '', '3159110', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(376, 'yes', 'Wagon', 'limbe', '', '3159123', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(377, 'yes', 'Wagon', 'limbe', '', '3152816', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(378, 'yes', 'Wagon', 'limbe', '', '3152829', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(379, 'yes', 'Wagon', 'limbe', '', '3169391', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(380, 'yes', 'Wagon', 'limbe', '', '3169401', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(381, 'yes', 'Wagon', 'limbe', '', '3162893', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(382, 'yes', 'Wagon', 'limbe', '', '3162903', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(383, 'yes', 'Wagon', 'limbe', '', '3151639', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(384, 'yes', 'Wagon', 'limbe', '', '3151642', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(385, 'yes', 'Wagon', 'limbe', '', '3157659', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(386, 'yes', 'Wagon', 'limbe', '', '3157662', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(387, 'yes', 'Wagon', 'limbe', '', '3160659', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(388, 'yes', 'Wagon', 'limbe', '', '3160662', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(389, 'yes', 'Wagon', 'limbe', '', '3158292', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(390, 'yes', 'Wagon', 'limbe', '', '3158302', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(391, 'yes', 'Wagon', 'limbe', '', '3154571', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(392, 'yes', 'Wagon', 'limbe', '', '3154584', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(393, 'yes', 'Wagon', 'limbe', '', '3157073', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(394, 'yes', 'Wagon', 'limbe', '', '3157086', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(395, 'yes', 'Wagon', 'limbe', '', '3152890', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(396, 'yes', 'Wagon', 'limbe', '', '3152900', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(397, 'yes', 'Wagon', 'limbe', '', '3151150', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(398, 'yes', 'Wagon', 'limbe', '', '3151163', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(399, 'yes', 'Wagon', 'limbe', '', '3153912', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(400, 'yes', 'Wagon', 'limbe', '', '3153925', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(401, 'yes', 'Wagon', 'limbe', '', '3167733', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(402, 'yes', 'Wagon', 'limbe', '', '3167746', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(403, 'yes', 'Wagon', 'limbe', '', '3167254', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(404, 'yes', 'Wagon', 'limbe', '', '3167267', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(405, 'yes', 'Wagon', 'limbe', '', '3151396', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(406, 'yes', 'Wagon', 'limbe', '', '3151406', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(407, 'yes', 'Wagon', 'limbe', '', '3170652', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(408, 'yes', 'Wagon', 'limbe', '', '3170665', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(409, 'yes', 'Wagon', 'limbe', '', '3174234', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(410, 'yes', 'Wagon', 'limbe', '', '3174768', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(411, 'yes', 'Wagon', 'limbe', '', '3173512', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(412, 'yes', 'Wagon', 'limbe', '', '3173621', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(413, 'yes', 'Wagon', 'limbe', '', '3152214', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(414, 'yes', 'Wagon', 'limbe', '', '3152227', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(415, 'yes', 'Wagon', 'limbe', '', '3160057', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(416, 'yes', 'Wagon', 'limbe', '', '3160060', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(417, 'yes', 'Wagon', 'limbe', '', '3158616', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(418, 'yes', 'Wagon', 'limbe', '', '3158629', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(419, 'yes', 'Wagon', 'limbe', '', '3169074', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(420, 'yes', 'Wagon', 'limbe', '', '3169087', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(421, 'yes', 'Wagon', 'limbe', '', '3160316', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(422, 'yes', 'Wagon', 'limbe', '', '3160329', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(423, 'yes', 'Wagon', 'limbe', '', '3159152', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(424, 'yes', 'Wagon', 'limbe', '', '3159165', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(425, 'yes', 'Wagon', 'limbe', '', '3169252', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(426, 'yes', 'Wagon', 'limbe', '', '3169265', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(427, 'yes', 'Wagon', 'limbe', '', '3153051', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(428, 'yes', 'Wagon', 'limbe', '', '3153064', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(429, 'yes', 'Wagon', 'limbe', '', '3152117', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(430, 'yes', 'Wagon', 'limbe', '', '3152120', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(431, 'yes', 'Wagon', 'limbe', '', '3169359', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(432, 'yes', 'Wagon', 'limbe', '', '3169362', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(433, 'yes', 'Wagon', 'limbe', '', '3169113', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(434, 'yes', 'Wagon', 'limbe', '', '3169126', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(435, 'yes', 'Wagon', 'limbe', '', '3155774', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(436, 'yes', 'Wagon', 'limbe', '', '3155787', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(437, 'yes', 'Wagon', 'limbe', '', '3166750', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(438, 'yes', 'Wagon', 'limbe', '', '3166763', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(439, 'yes', 'Wagon', 'limbe', '', '3152175', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(440, 'yes', 'Wagon', 'limbe', '', '3152188', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(441, 'yes', 'Wagon', 'limbe', '', '3152052', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(442, 'yes', 'Wagon', 'limbe', '', '3152065', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(443, 'yes', 'Wagon', 'limbe', '', '3160992', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(444, 'yes', 'Wagon', 'limbe', '', '3161001', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(445, 'yes', 'Wagon', 'limbe', '', '3165256', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(446, 'yes', 'Wagon', 'limbe', '', '3165269', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(447, 'yes', 'Wagon', 'limbe', '', '3154513', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(448, 'yes', 'Wagon', 'limbe', '', '3154526', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(449, 'yes', 'Wagon', 'limbe', '', '3162974', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(450, 'yes', 'Wagon', 'limbe', '', '3162987', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(451, 'yes', 'Wagon', 'limbe', '', '3159275', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(452, 'yes', 'Wagon', 'limbe', '', '3159288', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(453, 'yes', 'Wagon', 'limbe', '', '3151231', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(454, 'yes', 'Wagon', 'limbe', '', '3151244', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(455, 'yes', 'Wagon', 'limbe', '', '3156896', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(456, 'yes', 'Wagon', 'limbe', '', '3156906', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(457, 'yes', 'Wagon', 'limbe', '', '3150313', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(458, 'yes', 'Wagon', 'limbe', '', '3150326', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(459, 'yes', 'Wagon', 'limbe', '', '3167856', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(460, 'yes', 'Wagon', 'limbe', '', '3167869', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(461, 'yes', 'Wagon', 'limbe', '', '3152557', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(462, 'yes', 'Wagon', 'limbe', '', '3152560', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(463, 'yes', 'Wagon', 'limbe', '', '3166831', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(464, 'no', 'Wagon', 'limbe', '', '3166844', '', 'GONDOLA', 'HL6', '0', '', '', '', ''),
(466, 'no', 'wagon', 'limbe', '6', '8110749', '', 'hopper', 'bbe', '', 'loaded', '-133.0086', '215.8448', 'HOPPER11/29/2021 12:02 PM');

-- --------------------------------------------------------

--
-- Table structure for table `limbe_shunting_plan_control`
--

CREATE TABLE `limbe_shunting_plan_control` (
  `note_id` int(11) NOT NULL,
  `Noteboday` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`Noteboday`)),
  `TIME` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `limbe_shunting_plan_control`
--

INSERT INTO `limbe_shunting_plan_control` (`note_id`, `Noteboday`, `TIME`) VALUES
(4, '{\"noty\":[{\"planned_activities\":\"YARD SHUNT\",\"active_loco\":\"526\",\"wagon_plan\":\"5\",\"achieved_activities\":\"MOVED WAGON FROM TERMINAL TO YARD\",\"loco\":\"526\",\"wagon\":\"5\",\"time_plan\":\"8:00\",\"time_real_in\":\"10:00\",\"time_out_finish\":\"\",\"status\":\"\",\"comments\":\"\",\"pos\":\"1\"},{\"planned_activities\":\"HSHSH\",\"active_loco\":\"526\",\"wagon_plan\":\"\",\"achieved_activities\":\"sdsdsd\",\"loco\":\"\",\"wagon\":\"\",\"time_plan\":\"\",\"time_real_in\":\"\",\"time_out_finish\":\"\",\"status\":\"\",\"comments\":\"\",\"pos\":\"2\"},{\"planned_activities\":\"FDCD\",\"active_loco\":\"526\",\"wagon_plan\":\"\",\"achieved_activities\":\"\",\"loco\":\"\",\"wagon\":\"\",\"time_plan\":\"\",\"time_real_in\":\"\",\"time_out_finish\":\"\",\"status\":\"\",\"comments\":\"\",\"pos\":\"3\"},{\"planned_activities\":\"DVDDD\",\"active_loco\":\"526\",\"wagon_plan\":\"\",\"achieved_activities\":\"\",\"loco\":\"\",\"wagon\":\"\",\"time_plan\":\"\",\"time_real_in\":\"\",\"time_out_finish\":\"\",\"status\":\"\",\"comments\":\"\",\"pos\":\"4\"},{\"planned_activities\":\"DFEE\",\"active_loco\":\"526\",\"wagon_plan\":\"\",\"achieved_activities\":\"\",\"loco\":\"\",\"wagon\":\"\",\"time_plan\":\"\",\"time_real_in\":\"\",\"time_out_finish\":\"\",\"status\":\"\",\"comments\":\"\",\"pos\":\"5\"}]}', '2021-12-01 20:41:50');

-- --------------------------------------------------------

--
-- Table structure for table `limbe_shunting_plan_control_night`
--

CREATE TABLE `limbe_shunting_plan_control_night` (
  `note_id` int(11) NOT NULL,
  `Noteboday` longtext CHARACTER SET utf8mb4 COLLATE utf8mb4_bin NOT NULL CHECK (json_valid(`Noteboday`)),
  `TIME` timestamp NOT NULL DEFAULT current_timestamp() ON UPDATE current_timestamp()
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `limbe_shunting_plan_control_night`
--

INSERT INTO `limbe_shunting_plan_control_night` (`note_id`, `Noteboday`, `TIME`) VALUES
(4, '{\"noty\":[{\"planned_activities\":\"jlkjlklkjlkjlkljlkjlkjlk\",\"active_loco\":\"\",\"wagon_plan\":\"\",\"achieved_activities\":\"ertertert\",\"loco\":\"ertert\",\"wagon\":\"ert\",\"time_plan\":\"ert\",\"time_real_in\":\"ert\",\"time_out_finish\":\"ert\",\"status\":\"ert\",\"comments\":\"ertert\",\"pos\":\"1\"},{\"planned_activities\":\"lioijpojpopopop\",\"active_loco\":\"ert\",\"wagon_plan\":\"er\",\"achieved_activities\":\"teterrrrrrrrrrrrrrrrrrrr\",\"loco\":\"rrrte\",\"wagon\":\"eee\",\"time_plan\":\"eeeeeeeeeeeeeeeeeeeeee\",\"time_real_in\":\"eeeeeeeeeeeeeeeeeeeeer\",\"time_out_finish\":\"eeeeeeeeee\",\"status\":\"eeeeeeeeee\",\"comments\":\"eeeeeeeeeeeeeeeeeeee\",\"pos\":\"2\"},{\"planned_activities\":\"errrrrrrrrrrrrrrrr\",\"active_loco\":\"rrrrrrrr\",\"wagon_plan\":\"errrrrrrrrrrrrrrr\",\"achieved_activities\":\"rrrrrrrrrrrrrrrrrrrrrrrt\",\"loco\":\"e\",\"wagon\":\"rrrrrrrr\",\"time_plan\":\"rrrrrrrrrrr\",\"time_real_in\":\"r\",\"time_out_finish\":\"rrrrrrrrrrr\",\"status\":\"rrrrrrrrr\",\"comments\":\"rrrrrrrrrrrrrrrrrrrrrrrr\",\"pos\":\"3\"}]}', '2021-12-01 21:27:51');

-- --------------------------------------------------------

--
-- Table structure for table `object_persist`
--

CREATE TABLE `object_persist` (
  `object_id` int(11) NOT NULL,
  `name` varchar(100) NOT NULL,
  `posx` varchar(11) NOT NULL,
  `posy` varchar(11) NOT NULL,
  `obj_tag` varchar(50) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `object_persist`
--

INSERT INTO `object_persist` (`object_id`, `name`, `posx`, `posy`, `obj_tag`) VALUES
(217, 'HOPPER11/29/2021 12:02 PM', '-133.0086', '215.8448', 'HOPPER'),
(222, 'PASSENGER CAR11/29/2021 12:40 PM', '100.9914', '215.8448', 'PASSENGER CAR'),
(225, 'FLAT WAGON11/29/2021 12:42 PM', '216.9914', '215.8448', 'FLAT WAGON'),
(230, 'TANK11/29/2021 12:49 PM', '-253.0086', '215.8448', 'TANK'),
(232, 'GONDOLA11/29/2021 12:57 PM', '-17.00854', '215.8448', 'GONDOLA');

-- --------------------------------------------------------

--
-- Table structure for table `r_users`
--

CREATE TABLE `r_users` (
  `UU_ID` int(50) NOT NULL,
  `U_name` varchar(50) NOT NULL,
  `U_surname` varchar(50) NOT NULL,
  `U_userid` varchar(50) NOT NULL,
  `U_Password` varchar(255) NOT NULL,
  `isSuper_user` varchar(3) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4;

--
-- Dumping data for table `r_users`
--

INSERT INTO `r_users` (`UU_ID`, `U_name`, `U_surname`, `U_userid`, `U_Password`, `isSuper_user`) VALUES
(12, 'BRIAN', 'KACHULU', 'vvm8564', 'ce4974563e9ca323520b6b76316bc49e', 'yes'),
(15, 'kennedy', 'linzie', 'moon', 'a0910c489a6c9c242c898fd0bc5a4b78', 'yes'),
(16, 'kennedy', 'linzie', 'kenlinzie', 'a0910c489a6c9c242c898fd0bc5a4b78', 'yes');

-- --------------------------------------------------------

--
-- Table structure for table `train_history`
--

CREATE TABLE `train_history` (
  `transaction_id` int(20) NOT NULL,
  `Relesed_from_system` varchar(12) NOT NULL,
  `Vehicle Type` varchar(50) DEFAULT NULL,
  `Yard Sector` varchar(50) DEFAULT NULL,
  `Line` varchar(50) DEFAULT NULL,
  `Vehicle` varchar(50) DEFAULT NULL,
  `No of wagons` varchar(50) DEFAULT NULL,
  `Wagon type` varchar(50) DEFAULT NULL,
  `Series` varchar(50) DEFAULT NULL,
  `Date/Hour Last Event` varchar(50) DEFAULT NULL,
  `Status` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8;

--
-- Indexes for dumped tables
--

--
-- Indexes for table `all_data`
--
ALTER TABLE `all_data`
  ADD PRIMARY KEY (`transaction_id`),
  ADD UNIQUE KEY `Vehicle` (`Vehicle`);

--
-- Indexes for table `limbe_shunting_plan_control`
--
ALTER TABLE `limbe_shunting_plan_control`
  ADD PRIMARY KEY (`note_id`);

--
-- Indexes for table `limbe_shunting_plan_control_night`
--
ALTER TABLE `limbe_shunting_plan_control_night`
  ADD PRIMARY KEY (`note_id`);

--
-- Indexes for table `object_persist`
--
ALTER TABLE `object_persist`
  ADD PRIMARY KEY (`object_id`),
  ADD UNIQUE KEY `name` (`name`);

--
-- Indexes for table `r_users`
--
ALTER TABLE `r_users`
  ADD PRIMARY KEY (`UU_ID`),
  ADD UNIQUE KEY `U_userid` (`U_userid`);

--
-- Indexes for table `train_history`
--
ALTER TABLE `train_history`
  ADD PRIMARY KEY (`transaction_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `all_data`
--
ALTER TABLE `all_data`
  MODIFY `transaction_id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=469;

--
-- AUTO_INCREMENT for table `limbe_shunting_plan_control`
--
ALTER TABLE `limbe_shunting_plan_control`
  MODIFY `note_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `limbe_shunting_plan_control_night`
--
ALTER TABLE `limbe_shunting_plan_control_night`
  MODIFY `note_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- AUTO_INCREMENT for table `object_persist`
--
ALTER TABLE `object_persist`
  MODIFY `object_id` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=301;

--
-- AUTO_INCREMENT for table `r_users`
--
ALTER TABLE `r_users`
  MODIFY `UU_ID` int(50) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=17;

--
-- AUTO_INCREMENT for table `train_history`
--
ALTER TABLE `train_history`
  MODIFY `transaction_id` int(20) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=465;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
