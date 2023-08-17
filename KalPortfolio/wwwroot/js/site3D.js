import { Logo } from './three/logo.js'
function three() {
    const container = document.getElementById("scene-container");

    const logo = new Logo(container);

    logo.start();

}

three();
