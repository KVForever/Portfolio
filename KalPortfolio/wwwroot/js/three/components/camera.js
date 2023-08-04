import { PerspectiveCamera } from '../../../lib/three/build/three.module.js';

function createCamera(container) {
    const camera = new PerspectiveCamera(35, container.clientWidth / container.clientHeight, 0.1, 100);
  
    camera.position.set(0, 0, 10);

    //camera.translateX(-5);

    return camera;
}

export { createCamera };