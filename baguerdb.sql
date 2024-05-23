-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 23-05-2024 a las 11:49:59
-- Versión del servidor: 10.4.32-MariaDB
-- Versión de PHP: 8.2.12

SET SQL_MODE = "NO_AUTO_VALUE_ON_ZERO";
START TRANSACTION;
SET time_zone = "+00:00";


/*!40101 SET @OLD_CHARACTER_SET_CLIENT=@@CHARACTER_SET_CLIENT */;
/*!40101 SET @OLD_CHARACTER_SET_RESULTS=@@CHARACTER_SET_RESULTS */;
/*!40101 SET @OLD_COLLATION_CONNECTION=@@COLLATION_CONNECTION */;
/*!40101 SET NAMES utf8mb4 */;

--
-- Base de datos: `baguerdb`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `role`
--

CREATE TABLE `role` (
  `IdRol` int(11) NOT NULL,
  `Descripcion` varchar(50) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `role`
--

INSERT INTO `role` (`IdRol`, `Descripcion`) VALUES
(1, 'admin'),
(2, 'user'),
(3, 'employee');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `user`
--

CREATE TABLE `user` (
  `IdUser` int(11) NOT NULL,
  `Username` varchar(50) DEFAULT NULL,
  `Password` varchar(255) DEFAULT NULL,
  `Name` varchar(50) DEFAULT NULL,
  `RoleId` int(11) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `user`
--

INSERT INTO `user` (`IdUser`, `Username`, `Password`, `Name`, `RoleId`) VALUES
(2, 'hola', 'AQAAAAIAAYagAAAAED03U/jRrVNypOGWy9gKt3c9zzjli2sCxw', 'Santiago', 2),
(3, 'nuevo', 'AQAAAAIAAYagAAAAEDPOjPgRtwzRtSdHgOyQpiSbRAfNFMnbox', 'Niubi', 2),
(4, 'santiago', 'AQAAAAIAAYagAAAAEETK8O22hVj8k+iY2AkuBrnWlFasVyFa1r', 'delacruz', 2),
(5, 'pofavo', 'AQAAAAIAAYagAAAAEI3pvSRVUyYMoLV2VtkmikLckeIryGTLt3', 'gracias', 2),
(6, 'sofiaa', 'AQAAAAIAAYagAAAAEFDZdGead4WpZNKf0JdewftGHm7MgmgX4K', 'karen', 2),
(7, 'camentea', 'AQAAAAIAAYagAAAAEPNfPAt9RM3UaX9guJlVhRiONWcwzhtH87', 'carmen', 2),
(8, 'cebax', 'AQAAAAIAAYagAAAAEOoiTDQBrhTIoDuTJ8scH5VY2Tc5YQPwW5', 'sebastian', 2),
(9, 'camilin', 'AQAAAAIAAYagAAAAEFV2eusiiw/oaWZKzIHhsAni6e+p2bjHCHC9bU54odr3qqnazYZBOpWUAVTf2BDOZw==', 'camilo', 2),
(10, 'socio', 'AQAAAAIAAYagAAAAEPgqa4G+eAN1mU0oT70MBFQ14l8KEjor9CcVIyPsKnxzo3l5PitwrwQv4LSea3dAQQ==', 'socito', 2),
(11, 'Miguelin', 'AQAAAAIAAYagAAAAEO/1dhrkH/TGLUTS9csSXuse5QarflZrznnRvJlN5GkPDniDc/B3Etb0yXzX0OykQQ==', 'Miguel', 2),
(12, 'hei', 'AQAAAAIAAYagAAAAEL96au94dwAwrc3p9YRDGxOxwKazj8ChTtsQ/Lej8oNt2YBxp5Cz3hP0eD7AVFbDyg==', 'heisem', 2),
(13, 'johver', 'AQAAAAIAAYagAAAAEAsudmuA5VQdQ294zXOOv1YTTTykMMMGrxXiqQLYOvoH3wHMuHqPVwy+8nSNZUk0gg==', 'jholversito', 2);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `__efmigrationshistory`
--

CREATE TABLE `__efmigrationshistory` (
  `MigrationId` varchar(150) NOT NULL,
  `ProductVersion` varchar(32) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `__efmigrationshistory`
--

INSERT INTO `__efmigrationshistory` (`MigrationId`, `ProductVersion`) VALUES
('20240522225818_volta', '8.0.5'),
('20240523070921_bienAM', '8.0.5');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `role`
--
ALTER TABLE `role`
  ADD PRIMARY KEY (`IdRol`);

--
-- Indices de la tabla `user`
--
ALTER TABLE `user`
  ADD PRIMARY KEY (`IdUser`),
  ADD KEY `IX_User_RoleId` (`RoleId`);

--
-- Indices de la tabla `__efmigrationshistory`
--
ALTER TABLE `__efmigrationshistory`
  ADD PRIMARY KEY (`MigrationId`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `role`
--
ALTER TABLE `role`
  MODIFY `IdRol` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=4;

--
-- AUTO_INCREMENT de la tabla `user`
--
ALTER TABLE `user`
  MODIFY `IdUser` int(11) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=14;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `user`
--
ALTER TABLE `user`
  ADD CONSTRAINT `FK_User_Role_RoleId` FOREIGN KEY (`RoleId`) REFERENCES `role` (`IdRol`) ON DELETE CASCADE;
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
