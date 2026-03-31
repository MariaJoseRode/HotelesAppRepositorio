const e = require("express");
const { Router } = require("express");
const router = Router();



//Rutas GET

router.get("/", (req, res) => {
  console.log("Alguien accedió al servidor");
  res.send("Bienvenido al servidor");
});

router.get("/rutaGet", (req, res) => {
  console.log("Alguien hizo un get");
  res.send("Hola desde la ruta get!");
});

router.get("/reservas", (req, res) => {
  console.log("Alguien hizo a la pagina de reservas");
  res.send("Hola desde tu pagina de  reservas");
});

router.get("/gps", (req, res) => {
  console.log("Alguien hizo a la pagina de gps");
  res.send("Hola desde tu pagina del gps");
});

router.get("/favoritos", (req, res) => {
  console.log("Alguien hizo a la pagina de favoritos");
  res.send("Hola desde tus favoritos");
});

router.get("/ajustes", (req, res) => {
  console.log("Alguien hizo a la pagina de ajustes");
  res.send("Hola desde la pagina de ajustes");
});

router.get("/perfil", (req, res) => {
  console.log("Alguien hizo a la pagina de datos de usuario");
  res.send("Hola desde la pagina de datos de usuario");
});

router.get("/ayuda", (req, res) => {
  console.log("Alguien hizo a la pagina de ayuda");
  res.send("Hola desde la pagina de ayuda");
});

router.get("/FAQs", (req, res) => {
  console.log("Alguien hizo a la pagina de preguntas frecuentes");
  res.send("Hola desde la pagina de FAQs");
});

router.get("/detallehotel", (req, res) => {
  console.log("Alguien hizo a la pagina del detalle del hotel");
  res.send("Hola desde la pagina de detalle del hotel");
});


//Rutas POST

router.post("/login", (req, res) => {
  const email = req.body.usermail;
  const password = req.body.userpassword; 

  const ListaUsuarios = [
    { email: "pedro@ejemplo.com", password: "123456", nombre: "Pedro" },
    { email: "maria@terra.es", password: "abcdef", nombre: "Maria" },
    { email: "laura@dominio.com", password: "fedcba", nombre: "Laura" },
    { email: "marisa@ejemplo.es", password: "hola1234", nombre: "Marisa" }
  ];


  console.log("Se ha recibido una solicitud de inicio de sesión desde Unity");
  console.log("Email:", email);
  console.log("Contraseña:", password);

  const usuarioLogueado = ListaUsuarios.find(usuario => usuario.email === email && usuario.password === password);

  if (usuarioLogueado) {
    res.json({
            success: true,
            mensaje: "Te damos la bienvenida, " + usuarioLogueado.nombre + "!!"
        });
  }
  else {
    res.json({
      success: false, 
      mensaje: "Las credenciales son incorrectas, por favor revísalo y vuelve a intentarlo."
    })
  }
  });

router.post("/registro", (req, res) => {
  console.log("Se ha accedido al registro de la app");
  res.send("Hola, debes rellenar el formulario de registro");
});

router.post("/reservar", (req, res) => {
  console.log("Se ha accedido a la reserva de un hotel");
  res.send("Hola, debes rellenar el formulario de reserva");
});

router.post("/contacto", (req, res) => {
  console.log("Se ha accedido al formulario de contacto");
  res.send("Hola, debes rellenar el formulario de contacto");
});

router.post("/comentario", (req, res) => {
  console.log("Se ha accedido al formulario de comentario");
  res.send("Hola, debes rellenar el formulario de comentario");
});

router.post("/valoracion", (req, res) => {
  console.log("Se ha accedido al formulario de valoración");
  res.send("Hola, debes rellenar el formulario de valoración");
});

router.post("/cambioajustes", (req, res) => {
  req.body="Ajustes cambiados";
  console.log("Se ha accedido al formulario de cambio de ajustes");
  res.send("Hola, debes rellenar el formulario de cambio de ajustes");
}); 

router.post("/actualizardatos", (req, res) => {
  console.log("Se ha accedido al formulario de actualización de datos de usuario");
  res.send("Hola, debes rellenar el formulario de actualización de datos de usuario");
});



module.exports = router;
