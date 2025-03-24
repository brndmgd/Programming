input = open('input.txt').readlines() #input.txt - матрица весов графа
edges = dict()
visited = set()
comp = [i+1 for i in range(len(input))]

for i in range(len(input)):
    line = [int(k) for k in input[i].split()]
    for j in range(len(input)):
        if line[j] != 0:
            edges[(i+1, j+1)] = line[j]
edges = dict(sorted(edges.items(), key=lambda x: x[1]))
tree = []

for i in edges.keys():
    min_comp = min(comp[i[0] - 1], comp[i[1] - 1])
    max_comp = max(comp[i[0] - 1], comp[i[1] - 1])

    if not i[0] in visited and not i[1] in visited:
        comp[i[0] - 1] = comp[i[1] - 1] = min_comp
        tree.append(edges[i])

    elif comp[i[0] - 1] != comp[i[1] - 1]:
        tree.append(edges[i])
        for j in range(len(input)):
            if comp[j] == max_comp:
                comp[j] = min_comp

    visited.add(i[0])
    visited.add(i[1])

print(sum(tree))