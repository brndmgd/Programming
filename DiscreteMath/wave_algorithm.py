def neighbour(i: int, j: int, field: list):
    n1, n2, n3, n4 = field[i][j+1], field[i+1][j], field[i][j-1], field[i-1][j]
    cur = field[i][j] + 1
    n1 = cur if n1 != 'x' and (cur < n1 or n1 == -1) else n1
    n2 = cur if n2 != 'x' and (cur < n2 or n2 == -1) else n2
    n3 = cur if n3 != 'x' and (cur < n3 or n3 == -1) else n3
    n4 = cur if n4 != 'x' and (cur < n4 or n4 == -1) else n4
    field[i][j+1], field[i+1][j], field[i][j-1], field[i-1][j] = n1, n2, n3, n4


inp = open("input.txt").readlines()
field = []

for i in range(0, len(inp)):
    line = ['x'] + inp[i].split() + ['x']
    for j in range(len(line)):
        if line[j] != 'x':
            line[j] = int(line[j])
    field.append(line)

h = len(field)
w = len(field[0])
field.insert(0, ['x' for i in range(w)])
field.append(['x' for i in range(w)])

s = [int(i) for i in input().split()]
e = [int(i) for i in input().split()]
field[s[0]][s[1]] = 0

k = 0
while field[e[0]][e[1]] == -1:
    flag = False
    for i in range(h):
        if k in field[i]: flag = True
        for j in range(w):
            if field[i][j] == k:
                neighbour(i, j, field)
    if not flag: break
    k += 1

if field[e[0]][e[1]] == -1:
    print('Нет пути')
elif field[e[0]][e[1]] == 'x':
    print('Финиш - стена')
else:
    print("Путь займёт " + field[e[0]][e[1]])