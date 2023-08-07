import { createCamera } from './components/camera.js';
import { createK } from './components/createk.js';
import { createScene } from './components/scene.js';

import { createRenderer } from './systems/renderer.js';
import { Resizer } from './systems/Resizer.js';
import { Loop } from './systems/Loops.js';

let camera;
let renderer;
let scene;
let loop;

class Logo {

	constructor(container) {
		this.camera = createCamera(container);
		this.scene = createScene();
	    this.renderer = createRenderer(container);
		loop = new Loop(this.camera, this.scene, this.renderer);

		const logo = createK();

		
		loop.updatables.push(this.scene);
		

		logo.forEach((cube) => {
			this.scene.add(cube);
		});

		
		const resizer = new Resizer(container, this.camera, this.renderer);
	    resizer.onResize = () => {
			this.render();
		}		
	}

	render() {

		this.renderer.render(this.scene, this.camera);

	}

	start() {
		loop.start();
	}

	stop() {
		loop.stop();
	}
	
}

export { Logo }



