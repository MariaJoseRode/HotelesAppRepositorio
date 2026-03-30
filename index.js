console.log("Arrancando el servidor...");

const express = require("express");
const morgan = require("morgan");
const app = express();
const cors = require("cors");

app.set("port", process.env.PORT || 8080);
app.set("json spaces", 2);


app.use(morgan("dev"));
app.use(express.urlencoded({ extended: false }));
app.use(express.json());
app.use(cors());




app.use(require("./src/routes/index"));

app.listen(app.get("port"), () => {
  console.log("hola desde el puerto " + app.get("port"));
});
