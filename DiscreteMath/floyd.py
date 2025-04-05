file = open('input.txt')
prev_matrix = [[int(j) for j in i.split()] for i in file]

for k in range(len(prev_matrix)):
    D = [i for i in prev_matrix]
    for i in range(len(prev_matrix)):
        for j in range(len(prev_matrix)):
            if i == j:
                continue
            if prev_matrix[i][k] != 0 and prev_matrix[k][j] != 0:
                if prev_matrix[i][j] == 0:
                    D[i][j] = prev_matrix[i][k] + prev_matrix[k][j]
                else:
                    D[i][j] = min(prev_matrix[i][j], prev_matrix[i][k] + prev_matrix[k][j])
    prev_matrix = [i for i in D]

# Дальше код для красивой таблички
pad = max([max([len(str(j)) for j in i]) for i in prev_matrix]) * 2
print('\33[1m', end='')
print(('+' + '-' * pad) * (len(prev_matrix)+1) + "+")
for i in range(len(prev_matrix)+1):
    print('\33[1m' + '|' + '\33[0m', end='')
    if i == 0:
        print('\33[1m', end='')
        for j in range(len(prev_matrix) + 1):
            a = str(j) if j != 0 else ''
            print(str.center(a, pad), end='|')
        print('\33[0m', end='')
    else:
        for j in range(len(prev_matrix) + 1):
            a = str(prev_matrix[i-1][j-1]) if j != 0 else str(i)
            if a == '0': a = ''
            if j == 0: print('\33[1m', end='')
            print(str.center(a, pad), end='|')
            if j == 0: print('\33[0m', end='')
    print()
    if i == 0:
        print('\33[1m' + ('+' + '-' * pad + '+') + ('-' * pad + '+') * len(prev_matrix) + '\33[0m')
    else:
        print('\33[1m' + ('+' + '-' * pad + '+') + '\33[0m' + ('-' * pad + '+') * len(prev_matrix))
