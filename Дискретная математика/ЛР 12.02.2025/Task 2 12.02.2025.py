f = open('test1.txt')
matrix = []
for el in f:
    matrix.append(el.split())
vertexes = dict.fromkeys(el for el in range(0, len(matrix)))
vertexes[0] = 1
cnt = 1 #счетчик компонентов
for i in range(len(matrix)):
    for j in range(i):
        if matrix[j][i] == '1':
            if vertexes[i] != None:
                vertexes[i] = min(vertexes[i], vertexes[j])
                vertexes[j] = vertexes[i]
            else:
                vertexes[i] = vertexes[j]
    if vertexes[i] == None:
        cnt += 1
        vertexes[i] = cnt
components = max(vertexes.values())
print(f'Количество компонент связности графа: {components}')
