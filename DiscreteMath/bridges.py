def min_tree(edges, size):
    tree = []
    visited = set()
    comp = [i+1 for i in range(size)]

    for i in edges:
        min_comp = min(comp[i[0] - 1], comp[i[1] - 1])
        max_comp = max(comp[i[0] - 1], comp[i[1] - 1])

        if not i[0] in visited and not i[1] in visited:
            comp[i[0] - 1] = comp[i[1] - 1] = min_comp
            tree.append(i)

        elif comp[i[0] - 1] != comp[i[1] - 1]:
            tree.append(i)
            for j in range(len(input)):
                if comp[j] == max_comp:
                    comp[j] = min_comp

        visited.add(i[0])
        visited.add(i[1])
    return tree

def linked(weight_matrix, size, edge):
    cur_matrix = [[j for j in i] for i in weight_matrix]
    cur_matrix[edge[0]-1][edge[1]-1] = 0
    cur_matrix[edge[1]-1][edge[0]-1] = 0
    not_visited = [i+1 for i in range(size)]
    components = []

    while len(not_visited) > 0:
        cur_queue = []
        cur_queue.append(not_visited[0])
        not_visited.pop(0)
        k = 0

        while k < len(cur_queue):
            for i in range(len(not_visited)-1, -1, -1):
                if cur_matrix[cur_queue[k] - 1][not_visited[i] - 1] != 0:
                    cur_queue.append(not_visited[i])
                    not_visited.pop(i)
            k += 1
        components.append(cur_queue)

    return True if len(components) == 1 else False

input = open('input.txt').readlines()
edges = dict()
weight_matrix = []

for i in range(len(input)):
    line = [int(k) for k in input[i].split()]
    weight_matrix.append(line)
    for j in range(len(input)):
        if line[j] != 0:
            edges[(i+1, j+1)] = line[j]
edges = dict(sorted(edges.items(), key=lambda x: x[1]))
tree = min_tree(edges.keys(), len(input))

bridges = []
for i in tree:
    if not linked(weight_matrix, len(input), i):
        bridges.append(i)
print(bridges)
