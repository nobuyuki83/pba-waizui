using System.Collections.Generic;

public class TopologyOfUniformMesh
{
    static (int[], int[]) Vtx2Elem(int[] elem2vtx, int num_node, int num_vtx) {        
        int num_elem = elem2vtx.Length / num_node;
        int[] vtx2idx = new int[num_vtx+1];
        for(int i=0;i<vtx2idx.Length;++i){
            vtx2idx[i] = 0;
        }
        for(int i_elem=0;i_elem<num_elem;++i_elem) {
            for(int i_node=0;i_node<num_node;++i_node){
                int i_vtx = elem2vtx[i_elem * num_node + i_node];
                vtx2idx[i_vtx + 1] += 1;
            }
        }
        for(int i_vtx=0;i_vtx<num_vtx;++i_vtx) {
            vtx2idx[i_vtx + 1] += vtx2idx[i_vtx];
        }
        int num_idx = vtx2idx[num_vtx];
        // Debug.Log($"{num_idx}");
        int[] idx2elem = new int [num_idx];
        for (int i_elem = 0; i_elem < num_elem; i_elem++) {
            for (int i_node = 0; i_node < num_node; i_node++) {
                int i_vtx = elem2vtx[i_elem * num_node + i_node];
                int ind1 = vtx2idx[i_vtx];
                idx2elem[ind1] = i_elem;
                vtx2idx[i_vtx] += 1;
            }
        }
        for (int ivtx = num_vtx; ivtx >= 1; --ivtx) {
            vtx2idx[ivtx] = vtx2idx[ivtx - 1];
        }
        vtx2idx[0] = 0;
        return (vtx2idx, idx2elem);
    }    

    public static int[] Line2Vtx(int[] tri2vtx, int num_node, int num_vtx) {
        // Debug.Log($"num_tri {tri2vtx.Length / 3}, {num_vtx}");
        var vtx2elem = Vtx2Elem(tri2vtx, num_node, num_vtx);
        List<int> line2vtx = new List<int>();
        {
            int[] vtx2idx = vtx2elem.Item1;
            int[] idx2tri = vtx2elem.Item2;
            for(int i_vtx=0;i_vtx<num_vtx;++i_vtx){
                var neighbour_vtxs = new HashSet<int>();
                for(int idx=vtx2idx[i_vtx];idx<vtx2idx[i_vtx+1];++idx){
                    int i_elem = idx2tri[idx];
                    for(int i_node=0;i_node<num_node;++i_node){
                        int j_vtx = tri2vtx[i_elem * num_node + i_node];
                        if( j_vtx <= i_vtx ) continue;
                        neighbour_vtxs.Add(j_vtx);
                    }
                }
                foreach(int j_vtx in neighbour_vtxs){
                    line2vtx.Add(i_vtx);
                    line2vtx.Add(j_vtx);
                }                
            }
        }
        return line2vtx.ToArray();
    }

    public static (int[], int[]) Vtx2Vtx(int[] elem2vtx, int num_node, int num_vtx) {        
        var vtx2elem = Vtx2Elem(elem2vtx, num_node, num_vtx);
        int[] vtx2idx = vtx2elem.Item1;
        int[] idx2elem = vtx2elem.Item2;
        int[] vtx2jdx = new int [num_vtx+1];
        vtx2jdx[0] = 0;
        List<int> jdx2vtx = new List<int>();
        for(int i_vtx=0;i_vtx<num_vtx;++i_vtx){
            var set_connected_vtx = new HashSet<int>();
            for(int idx=vtx2idx[i_vtx];idx<vtx2idx[i_vtx+1];++idx){
                int i_elem = idx2elem[idx];
                for(int i_node=0;i_node<num_node;++i_node){
                    int j_vtx = elem2vtx[i_elem * num_node + i_node];
                    set_connected_vtx.Add(j_vtx);
                }
            }
            vtx2jdx[i_vtx+1] = vtx2jdx[i_vtx]+set_connected_vtx.Count;
            foreach(int j_vtx in set_connected_vtx) {
                jdx2vtx.Add(j_vtx);
            }
        }
        return (vtx2jdx, jdx2vtx.ToArray());
    }
}
