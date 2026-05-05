const { Router } = require("express");
const router = Router();
const mysql = require("mysql");

//  XAMPP local
const db = mysql.createConnection({
    host: "localhost",
    user: "root",
    password: "", 
    database: "hoteles_usuarios" 
});

db.connect((error) => {
    if (error) {
        console.log("Error en la conexión: " + error);
    } else {
        console.log("¡Conexión establecida con MySQL!");
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
            // Si hay un error (ej: la tabla no existe), avisamos
            return res.status(500).json({ success: false, error: err.message });
        }
        // Si todo va bien, enviamos la lista real de la base de datos
        res.json(result); 
    });
});

module.exports = router;