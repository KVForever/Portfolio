import { WebGLRenderer } from '../../../lib/three/build/three.module.js';

function createRenderer(container) {
    const renderer = new WebGLRenderer({ canvas: container });

    renderer.setSize(container.clientWidth, container.clientHeight);
    renderer.setPixelRatio(window.devicePixelRatio);

    
    return renderer;
}

export { createRenderer }