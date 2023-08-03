import { BoxGeometry, Mesh, MeshBasicMaterial } from '../../../lib/three/build/three.module.js';

function createK() {
    const geometry = new BoxGeometry(.4, 2, .3);
    const geometry2 = new BoxGeometry(1, .5, .3);
    const geometry3 = new BoxGeometry(1.25, .5, .3);

    const meterial = new MeshBasicMaterial();

    
    const cube = new Mesh(geometry, meterial);
    const cube2 = new Mesh(geometry2, meterial);
    const cube3 = new Mesh(geometry3, meterial);

    cube.rotateZ(-.25);

    cube2.rotateZ(.25);
    cube2.translateX(.6);
    cube2.translateY(.15);
    cube2.rotateZ(.25)

    cube3.rotateZ(-.25);
    cube3.translateX(.6);
    cube3.translateY(-.35);
    cube3.rotateZ(-.9);

    const object = [];
    object.push(cube, cube2, cube3);

    //object.forEach((o) => {
    //    o.tick = () => {
    //        object.forEach((b) => {
    //            b.rotateY(.01);
    //            b.rotateZ(.01);
    //            b.rotateX(.01);
    //        })
    //    }
    //})
    
    
    return object;
}

export { createK };