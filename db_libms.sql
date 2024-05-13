-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Host: 127.0.0.1
-- Generation Time: May 10, 2024 at 03:37 AM
-- Server version: 10.4.32-MariaDB
-- PHP Version: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Database: `db_libms`
--

-- --------------------------------------------------------

--
-- Table structure for table `log_authorization`
--

CREATE TABLE `log_authorization` (
  `id` int(100) NOT NULL,
  `username` varchar(255) NOT NULL,
  `password` varchar(255) NOT NULL,
  `authorization` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `log_authorization`
--

INSERT INTO `log_authorization` (`id`, `username`, `password`, `authorization`) VALUES
(1, 'user', 'user', 'user'),
(2, 'admin', 'admin', 'admin');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_book`
--

CREATE TABLE `tbl_book` (
  `id` int(255) NOT NULL,
  `book_title` varchar(255) NOT NULL,
  `book_author` varchar(255) NOT NULL,
  `book_category` varchar(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_book`
--

INSERT INTO `tbl_book` (`id`, `book_title`, `book_author`, `book_category`) VALUES
(1, 'The Shadow of Evermore', 'Lyra Nightshade', 'Fantasy'),
(2, 'Whispers in the Mist', 'Elijah', 'Mystery'),
(3, 'The Starlight Prophecy', 'Aria Silvermoon', 'Science Fiction'),
(4, 'Forgotten Realms', 'Cassandra Dawn', 'Adventure'),
(5, 'The Lost Chronicles', 'Sebastian Blackthorn', 'Historical Fiction'),
(6, 'Echoes of Eternity', 'Amara Starling', 'Romance'),
(7, 'Beyond the Veil', 'Thorn Ironwood', 'Horror'),
(8, 'Dreams of Destiny', 'Phoenix Summers', 'Young Adult'),
(9, 'The Clockwork Kingdom', 'Gideon Ironheart', 'Steampunk'),
(10, 'The Last Enchantment', 'Serenity Moonshadow', 'Fantasy'),
(11, 'The Shadow of Evermore', 'Lyra Nightshade', 'Fantasy'),
(12, 'Whispers in the Mist', 'Elijah Darkwood', 'Mystery'),
(13, 'The Starlight Prophecy', 'Aria Silvermoon', 'Science Fiction'),
(14, 'Forgotten Realms', 'Cassandra Dawn', 'Adventure'),
(15, 'The Lost Chronicles', 'Sebastian Blackthorn', 'Historical Fiction'),
(16, 'Echoes of Eternity', 'Amara Starling', 'Romance'),
(17, 'Beyond the Veil', 'Thorn Ironwood', 'Horror'),
(18, 'Dreams of Destiny', 'Phoenix Summers', 'Young Adult'),
(19, 'The Clockwork Kingdom', 'Gideon Ironheart', 'Steampunk'),
(20, 'The Last Enchantment', 'Serenity Moonshadow', 'Fantasy');

-- --------------------------------------------------------

--
-- Table structure for table `tbl_borrow_log`
--

CREATE TABLE `tbl_borrow_log` (
  `id` int(255) NOT NULL,
  `fullname` varchar(255) NOT NULL,
  `student_id` varchar(255) NOT NULL,
  `book_id` int(255) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Dumping data for table `tbl_borrow_log`
--

INSERT INTO `tbl_borrow_log` (`id`, `fullname`, `student_id`, `book_id`) VALUES
(1, 'Bev Abi', '21008', 4),
(4, 'Jessa and Dwarfs', '210123', 11);

--
-- Indexes for dumped tables
--

--
-- Indexes for table `log_authorization`
--
ALTER TABLE `log_authorization`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_book`
--
ALTER TABLE `tbl_book`
  ADD PRIMARY KEY (`id`);

--
-- Indexes for table `tbl_borrow_log`
--
ALTER TABLE `tbl_borrow_log`
  ADD PRIMARY KEY (`id`),
  ADD KEY `book_id` (`book_id`);

--
-- AUTO_INCREMENT for dumped tables
--

--
-- AUTO_INCREMENT for table `log_authorization`
--
ALTER TABLE `log_authorization`
  MODIFY `id` int(100) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=3;

--
-- AUTO_INCREMENT for table `tbl_book`
--
ALTER TABLE `tbl_book`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=22;

--
-- AUTO_INCREMENT for table `tbl_borrow_log`
--
ALTER TABLE `tbl_borrow_log`
  MODIFY `id` int(255) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Constraints for dumped tables
--

--
-- Constraints for table `tbl_borrow_log`
--
ALTER TABLE `tbl_borrow_log`
  ADD CONSTRAINT `book_log` FOREIGN KEY (`book_id`) REFERENCES `tbl_book` (`id`) ON DELETE NO ACTION ON UPDATE NO ACTION;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
