console.log("Arrancando el servidor...");

const express = require("express");
const morgan = require("morgan");
const app = express();



app.use(morgan("dev"));

app.set("port", process.env.PORT || 8080);

app.use(require("./src/routes/index"));

app.listen(app.get("port"), () => {
  console.log("hola desde el puerto " + app.get("port"));
});
