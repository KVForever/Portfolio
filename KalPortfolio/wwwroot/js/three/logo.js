import { createCamera } from './components/camera.js';
import { createK } from './components/createk.js';
import { createScene } from './components/scene.js';

import { createRenderer } from './systems/renderer.js';
import { Resizer } from './systems/Resizer.js';
//import { Loop } from './systems/Loop.js';

let camera;
let renderer;
let scene;
let loop;

class Logo {

	constructor(container) {
		this.camera = createCamera();
		this.scene = createScene();
	    this.renderer = createRenderer(container);
		//loop = new Loop(camera, scene, renderer);

		const logo = createK();
		logo.forEach((cube) => {
			this.scene.add(cube);
		});
		
	}

	render() {
		this.renderer.render(this.scene, this.camera);
	}

	
}

export { Logo }



/*
const container = document.getElementById("scene-container");

const scene = new THREE.Scene();

// Set the background color
scene.background = new THREE.Color('black');

// Create a camera
const fov = 35; // AKA Field of View
const aspect = container.clientWidth / container.clientHeight;
const near = 0.1; // the near clipping plane
const far = 100; // the far clipping plane

const camera = new THREE.PerspectiveCamera(fov, aspect, near, far);

// every object is initially created at ( 0, 0, 0 )
// move the camera back so we can view the scene
camera.position.set(0, 0, 10);

// create a geometry
const geometry = new THREE.BoxGeometry(.4, 2, .3);
const geometry2 = new THREE.BoxGeometry(1, .5, .3);
const geometry3 = new THREE.BoxGeometry(1.25, .5, .3);

// create a default (white) Basic material
const material = new THREE.MeshBasicMaterial();

// create a Mesh containing the geometry and material
const cube = new THREE.Mesh(geometry, material);
const cube2 = new THREE.Mesh(geometry2, material);
const cube3 = new THREE.Mesh(geometry3, material);
// add the mesh to the scene
scene.add(cube, cube2, cube3);

// create the renderer
const renderer = new THREE.WebGLRenderer({ canvas: container });

// next, set the renderer to the same size as our container element
renderer.setSize(container.clientWidth, container.clientHeight);

// finally, set the pixel ratio so that our scene will look good on HiDPI displays
renderer.setPixelRatio(window.devicePixelRatio);

//cube.rotateX(-1);
cube.rotateZ(-.25);

cube2.rotateZ(.25);
cube2.translateX(.6);
cube2.translateY(.15);
cube2.rotateZ(.25)

cube3.rotateZ(-.25);
cube3.translateX(.6);
cube3.translateY(-.35);
cube3.rotateZ(-.9);

camera.translateX(-3);
function animate() {
	requestAnimationFrame(animate);

	scene.rotation.y += 0.01;
	renderer.render(scene, camera);
}

// will keep looping making it look like the cube is rotating
animate()
*/

