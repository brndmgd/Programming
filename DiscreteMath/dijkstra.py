file = list(open("input.txt"))
start_vertex = int(input("Введите начальную вершину: "))
end_vertex = int(input("Введите конечную вершину: "))

weight = []
d = []
not_visited = []
for i in range(len(file)):
    cur_line = []
    not_visited.append(i)
    d.append('i')
    for j in file[i].split():
            cur_line.append(int(j))
    weight.append(cur_line)
d[start_vertex-1] = 0

while len(not_visited) != 0:
    temp_d = [d[i] for i in range(len(d)) if d[i] != 'i' and i in not_visited]
    cur_vertex = d.index(min(temp_d), min(not_visited))
    for i in range(len(weight[cur_vertex])):
        elem = weight[cur_vertex][i]
        if elem != 0:
            if d[i] == 'i': d[i] = elem + d[cur_vertex]
            else: d[i] = min(d[cur_vertex] + elem, d[i])
    not_visited.remove(cur_vertex)
print(d[end_vertex-1])