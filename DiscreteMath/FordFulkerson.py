import numpy as np

def BFS(graph, parent):

    visited = [False for i in range(len(graph))]
    queue = []
    queue.append(0)
    visited[0] = True

    while queue:
        v = queue.pop(0)

        for i in range(len(graph)):
            if visited[i] == False and graph[v][i] > 0:
                queue.append(i)
                visited[i] = True
                parent[i] = v

                if i == len(graph)-1:
                    return True
        
    return False


inp = open("input.txt")
graph = [[int(j) for j in i.split()] for i in inp]
parent = [-1 for i in graph]
max_flow = 0

while BFS(graph, parent):

    cur_flow = np.inf
    s = len(graph) - 1
    while(s != 0):
        cur_flow = min(cur_flow, graph[parent[s]][s])
        s = parent[s]
    max_flow += cur_flow
    s = len(graph) - 1
    while(s != 0):
        v = parent[s]
        graph[v][s] -= cur_flow
        graph[s][v] += cur_flow
        s = parent[s]

print("Максимальный поток равен", max_flow)
