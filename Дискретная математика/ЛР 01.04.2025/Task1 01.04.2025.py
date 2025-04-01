#волновой алгоритм
def find_way(pos_row, pos_col, value):
    if matrix[pos_row - 1][pos_col] == ' ':
        matrix[pos_row - 1][pos_col] = value + 1
    if matrix[pos_row + 1][pos_col] == ' ':
        matrix[pos_row + 1][pos_col] = value + 1
    if matrix[pos_row][pos_col - 1] == ' ':
        matrix[pos_row][pos_col - 1] = value + 1
    if matrix[pos_row][pos_col + 1] == ' ':
        matrix[pos_row][pos_col + 1] = value + 1

f = open('test2.txt')
matrix = []
for el in f:
    matrix.append([el[i] for i in range(0, len(el), 2)])

# положение старта и финиша
start = [4, 2]
finish = [4, 5]
matrix[start[0]][start[1]] = 0

for k in range(len(matrix)**2):
    if matrix[finish[0]][finish[1]] != ' ':
        break
    for i in range(len(matrix)):
        for j in range(len(matrix)):
            if matrix[i][j] != 'x' and matrix[i][j] != " ":
                find_way(i, j, matrix[i][j])

if matrix[finish[0]][finish[1]] != ' ':
    print(f'Дошел до финиша! Ответ: {matrix[finish[0]][finish[1]]}')
else:
    print("Не смог дойти до финиша")
