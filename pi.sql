-- phpMyAdmin SQL Dump
-- version 5.2.1
-- https://www.phpmyadmin.net/
--
-- Servidor: 127.0.0.1
-- Tiempo de generación: 10-05-2026 a las 11:36:55
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
-- Base de datos: `pi`
--

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `hoteles`
--

CREATE TABLE `hoteles` (
  `id_hotel` int(4) NOT NULL,
  `nombre_hotel` varchar(120) DEFAULT NULL,
  `descripcion` text DEFAULT NULL,
  `precio` int(200) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `hoteles`
--

INSERT INTO `hoteles` (`id_hotel`, `nombre_hotel`, `descripcion`, `precio`) VALUES
(1, 'Hotel Olympia', 'Hotel de 4 estrellas con spa', 85),
(2, 'Hotel Cascada', 'Hotel cerca de la montaña', 120),
(3, 'Hotel Pikachu', 'Un hotel electrizante', 23),
(4, 'Hotel ValenciaNova', 'Moderno y céntrico', 95),
(5, 'Hotel Mar Azul', 'Vistas increíbles al océano', 110),
(6, 'Hotel Sol', 'Perfecto para familias', 75),
(7, 'Gran Hotel Imperial', 'Lujo asiático en primera línea de playa con 5 piscinas y buffet libre internacional.', 251),
(8, 'Pensión La Pausa', 'Alojamiento económico y acogedor en el casco antiguo, ideal para mochileros.', 35),
(9, 'Resort Jungla Mágica', 'Duerme en una cabaña en un árbol rodeado de naturaleza salvaje y sonidos de aves.', 145),
(10, 'Hotel CyberPunk 2077', 'Habitaciones temáticas con luces neon, domótica avanzada y realidad virtual incluida.', 90),
(11, 'Apartamentos Brisa Marina', 'Apartamentos totalmente equipados con cocina y balcón con vistas directas al puerto.', 65);

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `hoteles_usuarios`
--

CREATE TABLE `hoteles_usuarios` (
  `ID` int(4) NOT NULL,
  `Usuario` varchar(50) NOT NULL,
  `Contraseña` varchar(200) NOT NULL
) ENGINE=InnoDB DEFAULT CHARSET=utf8mb4 COLLATE=utf8mb4_general_ci;

--
-- Volcado de datos para la tabla `hoteles_usuarios`
--

INSERT INTO `hoteles_usuarios` (`ID`, `Usuario`, `Contraseña`) VALUES
(1, 'Usuario001@mail.com', '12345'),
(2, 'Usuario002@mail.com', '56789'),
(3, 'Usuario003@mail.com', '456'),
(4, 'Croquetafeliz@mail.com', '333');

-- --------------------------------------------------------

--
-- Estructura de tabla para la tabla `perfiles`
--

CREATE TABLE `perfiles` (
  `id_usuario` int(4) NOT NULL,
  `email_usuario` varchar(255) NOT NULL,
  `nombre_completo` varchar(150) DEFAULT NULL,
  `direccion` varchar(300) DEFAULT NULL
) ENGINE=InnoDB DEFAULT CHARSET=latin1 COLLATE=latin1_swedish_ci;

--
-- Volcado de datos para la tabla `perfiles`
--

INSERT INTO `perfiles` (`id_usuario`, `email_usuario`, `nombre_completo`, `direccion`) VALUES
(0, '', '', ''),
(1, 'Usuario001@mail.com', 'Usuario Uno', 'Calle Falsa 123'),
(2, 'Usuario002@mail.com', 'Usuario Dos', 'Avenida Siempre Viva 742'),
(3, 'Usuario003@mail.com', 'Usuario Tres', 'Plaza Mayor 1'),
(4, 'Croquetafeliz@mail.com', 'Señor Croqueta', 'La Sartén 44');

--
-- Índices para tablas volcadas
--

--
-- Indices de la tabla `hoteles`
--
ALTER TABLE `hoteles`
  ADD PRIMARY KEY (`id_hotel`);

--
-- Indices de la tabla `hoteles_usuarios`
--
ALTER TABLE `hoteles_usuarios`
  ADD PRIMARY KEY (`ID`),
  ADD UNIQUE KEY `Usuario` (`Usuario`);

--
-- Indices de la tabla `perfiles`
--
ALTER TABLE `perfiles`
  ADD PRIMARY KEY (`id_usuario`),
  ADD UNIQUE KEY `email_usuario` (`email_usuario`);

--
-- AUTO_INCREMENT de las tablas volcadas
--

--
-- AUTO_INCREMENT de la tabla `hoteles`
--
ALTER TABLE `hoteles`
  MODIFY `id_hotel` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=12;

--
-- AUTO_INCREMENT de la tabla `hoteles_usuarios`
--
ALTER TABLE `hoteles_usuarios`
  MODIFY `ID` int(4) NOT NULL AUTO_INCREMENT, AUTO_INCREMENT=5;

--
-- Restricciones para tablas volcadas
--

--
-- Filtros para la tabla `hoteles_usuarios`
--
ALTER TABLE `hoteles_usuarios`
  ADD CONSTRAINT `fk_usuario_perfil` FOREIGN KEY (`ID`) REFERENCES `perfiles` (`id_usuario`);
COMMIT;

/*!40101 SET CHARACTER_SET_CLIENT=@OLD_CHARACTER_SET_CLIENT */;
/*!40101 SET CHARACTER_SET_RESULTS=@OLD_CHARACTER_SET_RESULTS */;
/*!40101 SET COLLATION_CONNECTION=@OLD_COLLATION_CONNECTION */;
