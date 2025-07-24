//
// SPDX-License-Identifier: CC0-1.0
//
// This example code file is released to the public under Creative Commons CC0.
// See https://creativecommons.org/publicdomain/zero/1.0/legalcode
//
// To the extent possible under law, the author has waived all copyright and
// related or neighboring rights to this example code file.
//
// THE SOFTWARE IS PROVIDED “AS IS”, WITHOUT WARRANTY OF ANY KIND, EXPRESS
// OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
// FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
// AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
// LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
// OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN
// THE SOFTWARE.
//

using PicoGK;
using System.Numerics;

namespace PicoGKExamples
{
    /// <summary>
    /// This example shows simple voxel-based boolean operations
    /// </summary>
    class BooleanShowCase
    {
        public static void Task()
        {
            // Create some nice materials for our viewer

            Library.oViewer().SetGroupMaterial(0, "555577", 0.7f, 0.8f);
            // Dark metallic

            Library.oViewer().SetGroupMaterial(1, "AA000033", 0.1f, 0);
            // Transparent Red

            Library.oViewer().SetGroupMaterial(2, "00AA0033", 0.1f, 0);
            // Transparent Green

            // --- Boolean Add Showcase ---

            // Create two voxel fields from spheres
            Voxels vox1A = Voxels.voxSphere(new Vector3(-10f, 0, 0), 20f);
            Voxels vox1B = Voxels.voxSphere(new Vector3(10f, 0, 0), 20f);

            // add the two voxel fields together (the result overlaps)
            Voxels vox1 = vox1A + vox1B;

            // Add the result to the viewer
            Library.oViewer().Add(vox1);

            // --- Boolean Subtract Showcase ---

            // create two voxel fields from spheres
            Voxels vox2A = Voxels.voxSphere(new Vector3(-10f + 90, 0, 0), 20f);
            Voxels vox2B = Voxels.voxSphere(new Vector3(10f + 90, 0, 0), 20f);

            // subtract the voxel fields from each other
            Voxels vox2 = vox2A - vox2B;
               
            Library.oViewer().Add(vox2);
            Library.oViewer().Add(vox2B, 1);

            // --- Boolean Intersect Showcase ---

            // Create two spheres
            Voxels vox3A = Voxels.voxSphere(new Vector3(-10f + 180, 0, 0), 20f);
            Voxels vox3B = Voxels.voxSphere(new Vector3(10f + 180, 0, 0), 20f);

            // Intersect the two voxel fields with each other
            Voxels vox3 = vox3A & vox3B;

            Library.oViewer().Add(vox3);
            Library.oViewer().Add(vox3A, 2);
            Library.oViewer().Add(vox3B, 2);

            // --- Save the results ---

            // Add all three results in one voxel field
            Voxels voxAll = vox1 + vox2 + vox3;

            // convert to mesh and save as .STL file
            Mesh msh = new Mesh(voxAll);
            msh.SaveToStlFile(  Path.Combine(Library.strLogFolder,
                                    "Booleans.stl"));
        }
    }
}