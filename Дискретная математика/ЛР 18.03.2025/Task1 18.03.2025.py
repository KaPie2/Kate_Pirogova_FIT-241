#алгоритм флойда
import sys

f = open('test1.txt')
main_matrix = []
for el in f:
    main_matrix.append([sys.maxsize if i == "-1" else int(i) for i in el.split()])

for k in range(len(main_matrix)):
    new_matrix = main_matrix[:]
    for i in range(len(main_matrix)):
        for j in range(len(main_matrix)):
            new_matrix[i][j] = min(main_matrix[i][k] + main_matrix[k][j], main_matrix[i][j])
    main_matrix = new_matrix[:]

#вывод ответа
print("\t", '\t'.join([str(n + 1) for n in range(len(new_matrix))]))
for i in range(len(new_matrix)):
    print(f"{i + 1}\t{'\t'.join([str(el) for el in new_matrix[i]])}")
