from sklearn import svm
import numpy as np

#from sklearn.grid_search import GridSearchCV 

print("Load data and Learning")

none = np.loadtxt("traindata/none_Brainwavelog.txt",delimiter=",")
none = none[:,2:]
print(none.shape)

attack = np.loadtxt("traindata/Attack_Brainwavelog.txt",delimiter=",")
attack = attack[:,2:]
print(attack.shape)

defence = np.loadtxt("traindata/defence_Brainwavelog.txt",delimiter=",")
defence = defence[:,2:]
print(defence.shape)

none_label = np.ones((none.shape[0])) * 0
attack_label = np.ones((attack.shape[0])) * 1
defence_label = np.ones((defence.shape[0])) * 2

data = np.concatenate([none,attack,defence])
#print(data.shape)
data_label = np.concatenate([none_label,attack_label,defence_label])
#print(data_label.shape)
#print(data_label)


#clf = svm.LinearSVC()
clf = svm.SVC()
#tuned_parameters=[{'C':[1,20,100,1000],'kernel':['linear']}]
#clf=GridSearchCV( SVC(), tuned_parameters,cv=5,scoreing='f1')


clf.fit(data,data_label)
predict_result = clf.predict(data)
correct_ansewer = 0
for i in range(predict_result.shape[0]):
    if(predict_result[i]==data_label[i]):
        correct_ansewer = correct_ansewer + 1

print("SVC training data score : "+str(correct_ansewer/predict_result.shape[0] ))

import os
import time

while(True):
    #フォルダ監視
    print("waiting file")
    filepath = "../Brainwavelog.txt"
    if(os.path.exists(filepath)):
        try:
            print("get file")
            now_data = np.loadtxt(filepath,delimiter=",")
            now_data = now_data[-1:,2:]
            now_result = clf.predict(now_data)
            print(now_result)
            np.savetxt("../result",now_result)
        except:
            pass
    time.sleep(2)


if(True):
    print(correct_ansewer/predict_result.shape[0])

    print(clf.predict(attack))



    print(clf.get_params)
    print(clf.score(data,data_label))
    df = clf.decision_function(data)
    print(df.shape)
    print(df)
    #print("dual_coef")
    #print(clf.dual_coef_.shape)

    print("support_")
    print(clf.support_.shape)
    print(clf.support_)
    print("support_vectors")
    print(clf.support_vectors_.shape)
    print(clf.support_vectors_)