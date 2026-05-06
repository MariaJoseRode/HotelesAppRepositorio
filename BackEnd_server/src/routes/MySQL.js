const { Router } = require("express");
const router = Router();
const mysql = require("mysql");

//  XAMPP local ANTIGUAAAAA
//const db = mysql.createConnection({
 //   host: "localhost",
 //   user: "root",
 //   password: "", 
 //   database: "hoteles_usuarios" 
//});

// NUEVA BBDD !!!!!
// --- CONFIGURACIÓN DE LA BASE DE DATOS ONLINE!!!!   (FreeSQLDatabase) ---
const db = mysql.createConnection({
    host: "sql7.freesqldatabase.com",
    port: 3306,
    user: "sql7825618",
    password: "s9NrKq221V", 
    database: "sql7825618" 
});



db.connect((error) => {
    if (error) {
        console.log("Error en la conexión: " + error);
    } else {
        console.log("¡Conexión establecida con MySQL ONLINE!");
    }
});

// --- ruta get --
router.get("/getSQL", (req, res) => {
    let sql = "SELECT * FROM hoteles_usuarios"; 
    db.query(sql, (err, result) => {
        if (err) return res.status(500).send(err);
        res.json(result); 
    });
}); 

//-- ruta post ---
router.post("/postSQL", (req, res) => {
    
   // let post = { Usuario: "pruebaNODE", Contraseña: "12345" }; 
   //http://localhost:8080/api/MySQL/postSQL
   let NuevoUsuario = { 
        Usuario: req.body.usuario,
        Contraseña: req.body.pass
    }; 
    let sql = "INSERT INTO hoteles_usuarios SET ?";
    
    db.query(sql, NuevoUsuario, (err, result) => {
        //en estas partes se ha añadido un if else por si hay algun error, para que el sistema no se quede colgado.
        if (err) {
            res.status(500).json({ error: err });
        } else {
            console.log(result);
            res.json(result); 
        }
    });
});


//Ruta POST para login
router.post("/login", (req, res) => {
    let mailRecibido = req.body.usuario;
    let contrasenyaRecibida = req.body.pass;

    let sql = "SELECT * FROM hoteles_usuarios WHERE Usuario = ? and Contraseña = ?";

    db.query(sql, [mailRecibido, contrasenyaRecibida], (err, result) => {
            //Error de conexión
        if (err) {
              return res.status(500).json({success: false, mensaje: "Error del servidor " + err.message});
            }
            //Result mayor que 0, ha encontrado una coincidencia
            if (result.length > 0){
                    res.json({ success: true, mensaje: "¡Login correcto! Bienvenido/a." });
        } else {
                     res.json({ success: false, mensaje: "Parece que hay un error" });
            }
    });

});

// Ruta POST para guardar los datos del perfil
router.post("/guardarPerfil", (req, res) => {
    //Variable que recoge los datos de unity
    let nuevoPerfil = {
        nombre_completo: req.body.NombreUnity,
        direccion: req.body.DireccionUnity
    };
    
    //Inserción en la BBDD "perfiles"
    let sql = "INSERT INTO perfiles SET ?";

    db.query (sql, nuevoPerfil, (err, result) => {
        if (err) return res.status(500).json({ success: false, error: err.message});
        res.json({success: true, mensaje: "Se han guardado los datos de tu perfil"})
    });
});


// --- NUEVA RUTA PARA OBTENER LOS HOTELES DE LA BBDD ---
router.get("/listaHoteles", (req, res) => {
    // Esta es la consulta SQL para traer todos los datos de la tabla hoteles
    let sql = "SELECT * FROM hoteles"; 
    
    db.query(sql, (err, result) => {
        if (err) {
            // Si hay un error en la consulta, respondemos con un error 500 y el mensaje del error
            return res.status(500).json({ success: false, error: err.message });
        }
        
        res.json(result); 
    });
    ///http://localhost:8080/api/MySQL/listaHoteles
});


// --- RUTA PARA OBTENER UN HOTEL ESPECÍFICO ---
router.get("/detalleHotel/:id", (req, res) => {
    const idRecibido = req.params.id; 
    // CAMBIO AQUÍ: Usamos id_hotel en lugar de id
    const sql = "SELECT * FROM hoteles WHERE id_hotel = ?"; 

    db.query(sql, [idRecibido], (err, result) => {
        if (err) {
            return res.status(500).json({ success: false, error: err.message });
        }
        
        if (result.length > 0) {
            res.json(result[0]); // Devuelve el hotel encontrado
        } else {
            res.status(404).json({ success: false, mensaje: "No existe el hotel con ese ID" });
        }
    });
});


router.get("/buscarHotel/:nombre", (req, res) => {
    const nombreBusqueda = `%${req.params.nombre}%`;
    const sql = "SELECT * FROM hoteles WHERE nombre_hotel LIKE ?";  //lenguaje SQL para buscar por nombre, el % es un comodín que permite encontrar coincidencias parciales

    db.query(sql, [nombreBusqueda], (err, result) => {
        if (err) return res.status(500).json({ success: false, error: err.message });

        if (result.length > 0) {
            
            res.json({ success: true, datos: result });
        } else {
            res.json({ success: false, datos: [] });
        }
    });
});

module.exports = router;