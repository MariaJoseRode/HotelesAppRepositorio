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
    
    let post = { Usuario: "pruebaNODE", Contraseña: "12345" }; 
    let sql = "INSERT INTO hoteles_usuarios SET ?";
    
    db.query(sql, post, (err, result) => {
        //en estas partes se ha añadido un if else por si hay algun error, para que el sistema no se quede colgado.
        if (err) {
            res.status(500).json({ error: err });
        } else {
            console.log(result);
            res.json(result); 
        }
    });
});

module.exports = router;