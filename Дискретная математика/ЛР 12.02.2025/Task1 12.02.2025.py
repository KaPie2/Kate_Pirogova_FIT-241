def find_components(n):
    data.append(n)
    for i in range(0, len(matrix)):
        if matrix[n][i] == '1' and (i not in data):
            copy_vertexes.remove(i)
            find_components(i)
    return data

f = open('file.txt')
matrix = []
for el in f:
    matrix.append(el.split())
vertexes = list(range(0, len(matrix)))
copy_vertexes = vertexes.copy()
components = []
while copy_vertexes != []:
    data = []
    find_components(copy_vertexes[0])
    copy_vertexes.remove(copy_vertexes[0])
    components.append(data)
print(len(components))
