file = open('input.txt').readlines()
start = int(input())
weight_matrix = []
lengths = []

for i in range(len(file)):
    line = [int(i) for i in file[i].split()]
    lengths.append('i')
    weight_matrix.append(line)
lengths[start-1] = 0

for k in range(1, len(weight_matrix)):
    for i in range(len(weight_matrix)):
        for j in range(len(weight_matrix)):
            if lengths[i] == 'i':
                lengths[i] = weight_matrix[j][i] + lengths[j] if weight_matrix[j][i] != 0 else 'i'
            else:
                if lengths[j] != 'i' and weight_matrix[j][i] != 0:
                    lengths[i] = min(weight_matrix[j][i] + lengths[j], lengths[i])

for i in range(len(lengths)):
    print(f'Расстояние до вершины {i+1}: {lengths[i]}')
